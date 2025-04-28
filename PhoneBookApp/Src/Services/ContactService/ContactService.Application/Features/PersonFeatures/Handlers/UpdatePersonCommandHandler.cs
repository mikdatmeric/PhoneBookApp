using AutoMapper;
using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Handlers
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var existingPerson = await _unitOfWork.PersonRepository.GetByIdAsync(request.Person.Id);
            if (existingPerson == null)
                return new BaseResponse<Guid>("Person not found.");

            _mapper.Map(request.Person, existingPerson);

            _unitOfWork.PersonRepository.UpdateAsync(existingPerson);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(existingPerson.Id);
        }
    }

}
