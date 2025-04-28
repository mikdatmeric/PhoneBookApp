using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.WindowsServices;
using ReportService.Infrastructure.Persistence.Contexts;
using ReportService.Worker.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<KafkaConsumerService>();

        services.AddDbContext<ReportDbContext>(options =>
            options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection")));
    })
    .Build();

await host.RunAsync();