using MediatR;
using Shared.BaseResponses.Response;

namespace ReportService.Application.Features.Commands
{
    public class CreateReportCommand : IRequest<BaseResponse<Guid>>
    {
    }
}
