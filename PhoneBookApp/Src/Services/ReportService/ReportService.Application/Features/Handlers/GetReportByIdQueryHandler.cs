using AutoMapper;
using MediatR;
using ReportService.Application.DTOs;
using ReportService.Application.Features.Queries;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;
using Shared.BaseResponses.Response;

namespace ReportService.Application.Features.Handlers
{
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, BaseResponse<ReportDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReportByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ReportDto>> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _unitOfWork.ReportRepository.GetByIdAsync(request.ReportId);
            if (report == null)
                return BaseResponse<ReportDto>.Fail("Rapor bulunamadı.");

            var reportDto = _mapper.Map<ReportDto>(report);
            return new BaseResponse<ReportDto>(reportDto);
        }
    }

}
