using ReportService.Application.DTOs;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.Abstract
{
    public interface IReportService
    {
        Task<BaseResponse<Guid>> CreateReportAsync();
        Task<BaseResponse<List<ReportDto>>> GetAllReportsAsync();
        Task<BaseResponse<ReportDto>> GetReportByIdAsync(Guid id);
    }
}
