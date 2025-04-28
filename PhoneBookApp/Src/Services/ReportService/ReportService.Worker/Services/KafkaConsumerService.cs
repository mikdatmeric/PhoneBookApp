using Confluent.Kafka;
using ReportService.Infrastructure.Persistence.Contexts;
using Shared.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ReportService.Domain.Enums.Enums;

namespace ReportService.Worker.Services
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public KafkaConsumerService(IServiceScopeFactory scopeFactory, IConfiguration configuration)
        {
            _scopeFactory = scopeFactory;
            _configuration = configuration;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/"); // ContactService.Api adresi
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
                GroupId = _configuration["Kafka:GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            var topicName = _configuration["Kafka:Topic"];

            using var consumer = new ConsumerBuilder<Null, string>(config).Build();
            consumer.Subscribe(topicName);

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(stoppingToken);
                var reportEvent = JsonSerializer.Deserialize<ReportRequestedEvent>(consumeResult.Message.Value);

                if (reportEvent != null)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<ReportDbContext>();

                    var report = await dbContext.Reports.FindAsync(reportEvent.ReportId);

                    if (report != null)
                    {
                        var persons = await _httpClient.GetFromJsonAsync<List<PersonDto>>("api/person");

                        if (persons != null)
                        {
                            var locationStats = persons
                                .SelectMany(p => p.ContactInfos)
                                .Where(ci => ci.Type == "Location")
                                .GroupBy(ci => ci.Content)
                                .Select(g => new
                                {
                                    Location = g.Key,
                                    PersonCount = persons.Count(p => p.ContactInfos.Any(ci => ci.Type == "Location" && ci.Content == g.Key)),
                                    PhoneNumberCount = persons
                                        .Where(p => p.ContactInfos.Any(ci => ci.Type == "Location" && ci.Content == g.Key))
                                        .SelectMany(p => p.ContactInfos)
                                        .Count(ci => ci.Type == "PhoneNumber")
                                })
                                .ToList();

                            var csvContent = "Location,PersonCount,PhoneNumberCount\n";
                            foreach (var stat in locationStats)
                            {
                                csvContent += $"{stat.Location},{stat.PersonCount},{stat.PhoneNumberCount}\n";
                            }

                            var filePath = $"Reports/{Guid.NewGuid()}.csv";
                            Directory.CreateDirectory("Reports");
                            await File.WriteAllTextAsync(filePath, csvContent);

                            report.Status = ReportStatus.Completed;
                            report.FilePath = filePath;

                            await dbContext.SaveChangesAsync();
                        }
                    }
                }
            }
        }
    }

    // Mini Dto
    public class PersonDto
    {
        public Guid Id { get; set; }
        public List<ContactInfoDto> ContactInfos { get; set; } = new();
    }

    public class ContactInfoDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
