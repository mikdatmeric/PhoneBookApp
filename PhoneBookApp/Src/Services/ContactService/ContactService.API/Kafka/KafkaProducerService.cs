using Confluent.Kafka;
using Shared.Events.Events;
using System.Text.Json;

namespace ContactService.API.Kafka
{
    public class KafkaProducerService
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topicName = "report-requests";

        public KafkaProducerService()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task PublishReportRequestAsync(Guid reportId)
        {
            var @event = new ReportRequestedEvent { ReportId = reportId };
            var message = JsonSerializer.Serialize(@event);

            await _producer.ProduceAsync(_topicName, new Message<Null, string> { Value = message });
        }
    }
}
