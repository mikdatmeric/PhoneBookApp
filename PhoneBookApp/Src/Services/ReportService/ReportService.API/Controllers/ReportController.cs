using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.DTOs;
using ReportService.Application.Services.Abstract;
using Shared.BaseResponses.Response;

namespace ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Guid>>> Create()
        {
            var result = await _reportService.CreateReportAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ReportDto>>>> GetAll()
        {
            var result = await _reportService.GetAllReportsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ReportDto>>> GetById(Guid id)
        {
            var result = await _reportService.GetReportByIdAsync(id);
            return Ok(result);
        }
    }
}
