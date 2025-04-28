using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Handlers
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Guid>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.PersonId);
            if (person == null)
                return new BaseResponse<Guid>("Person not found.");

            _unitOfWork.PersonRepository.DeleteAsync(person);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(person.Id);
        }
    }

}
