using MediatR;
using ReportService.Application.DTOs;
using ReportService.Application.Features.Commands;
using ReportService.Application.Features.Queries;
using ReportService.Application.Services.Abstract;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IMediator _mediator;

        public ReportManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResponse<Guid>> CreateReportAsync()
        {
            var command = new CreateReportCommand();
            return await _mediator.Send(command);
        }

        public async Task<BaseResponse<List<ReportDto>>> GetAllReportsAsync()
        {
            var query = new GetAllReportsQuery();
            return await _mediator.Send(query);
        }

        public async Task<BaseResponse<ReportDto>> GetReportByIdAsync(Guid id)
        {
            var query = new GetReportByIdQuery(id);
            return await _mediator.Send(query);
        }
    }
}
