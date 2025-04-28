using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.PersonFeatures.Queries;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, BaseResponse<PersonDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PersonDetailDto>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository
                .GetAllQueryable()
                .Include(p => p.ContactInfos)
                .FirstOrDefaultAsync(p => p.Id == request.PersonId, cancellationToken);

            if (person == null)
                return BaseResponse<PersonDetailDto>.Fail("Person not found.");

            var personDetailDto = _mapper.Map<PersonDetailDto>(person);

            return new BaseResponse<PersonDetailDto>(personDetailDto);
        }
    }

}
