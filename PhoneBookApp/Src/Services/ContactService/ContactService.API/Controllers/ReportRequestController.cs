using ContactService.API.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRequestController : ControllerBase
    {
        private readonly KafkaProducerService _kafkaProducerService;

        public ReportRequestController()
        {
            _kafkaProducerService = new KafkaProducerService();
        }

        [HttpPost("{reportId}")]
        public async Task<IActionResult> RequestReport(Guid reportId)
        {
            await _kafkaProducerService.PublishReportRequestAsync(reportId);
            return Ok();
        }
    }
}
