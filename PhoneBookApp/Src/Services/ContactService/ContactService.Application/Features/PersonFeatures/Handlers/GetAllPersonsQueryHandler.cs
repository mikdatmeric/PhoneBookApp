using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.PersonFeatures.Queries;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Handlers
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, BaseResponse<List<PersonDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPersonsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<PersonDto>>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = await _unitOfWork.PersonRepository.GetAllAsync();
            var personDtos = _mapper.Map<List<PersonDto>>(persons);

            return new BaseResponse<List<PersonDto>>(personDtos);
        }
    }

}
