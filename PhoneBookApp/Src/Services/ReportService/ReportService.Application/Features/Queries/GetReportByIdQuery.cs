using MediatR;
using ReportService.Application.DTOs;
using Shared.BaseResponses.Response;

namespace ReportService.Application.Features.Queries
{
    public class GetReportByIdQuery : IRequest<BaseResponse<ReportDto>>
    {
        public Guid ReportId { get; set; }

        public GetReportByIdQuery(Guid reportId)
        {
            ReportId = reportId;
        }
    }
}
