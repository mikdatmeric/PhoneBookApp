using AutoMapper;
using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Handlers
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var personEntity = _mapper.Map<Person>(request.Person);

            await _unitOfWork.PersonRepository.AddAsync(personEntity);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(personEntity.Id);
        }
    }

}
