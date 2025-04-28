using MediatR;
using ReportService.Application.Features.Commands;
using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReportService.Domain.Enums.Enums;

namespace ReportService.Application.Features.Handlers
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Guid>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report
            {
                Id = Guid.NewGuid(),
                RequestedAt = DateTime.UtcNow,
                Status = ReportStatus.Preparing
            };

            await _unitOfWork.ReportRepository.AddAsync(report);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(report.Id);
        }
    }

}
