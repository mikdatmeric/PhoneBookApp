using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Handlers
{
    public class DeleteContactInfoCommandHandler : IRequestHandler<DeleteContactInfoCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<Guid>> Handle(DeleteContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = await _unitOfWork.ContactInfoRepository.GetByIdAsync(request.ContactInfoId);
            if (contactInfo == null)
                return BaseResponse<Guid>.Fail("Contact Info not found.");

            _unitOfWork.ContactInfoRepository.DeleteAsync(contactInfo);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(contactInfo.Id);
        }
    }
}
