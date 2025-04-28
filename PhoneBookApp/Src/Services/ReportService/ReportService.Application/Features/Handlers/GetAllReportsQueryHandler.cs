using AutoMapper;
using MediatR;
using ReportService.Application.DTOs;
using ReportService.Application.Features.Queries;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;
using Shared.BaseResponses.Response;

namespace ReportService.Application.Features.Handlers
{
    public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, BaseResponse<List<ReportDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReportsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ReportDto>>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _unitOfWork.ReportRepository.GetAllAsync();
            var reportDtos = _mapper.Map<List<ReportDto>>(reports);

            return new BaseResponse<List<ReportDto>>(reportDtos);
        }
    }

}
