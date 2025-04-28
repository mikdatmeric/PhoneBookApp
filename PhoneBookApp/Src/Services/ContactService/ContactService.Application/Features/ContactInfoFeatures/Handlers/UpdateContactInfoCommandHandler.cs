using AutoMapper;
using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Application.Features.ContactInfoFeatures.Handlers
{
    public partial class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateContactInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var existingContactInfo = await _unitOfWork.ContactInfoRepository.GetByIdAsync(request.ContactInfo.Id);
            if (existingContactInfo == null)
                return new BaseResponse<Guid>("Contact Info not found.");

            // Burada Type ve Content güncellemesi yapılacak.
            existingContactInfo.Content = request.ContactInfo.Content;

            if (Enum.TryParse<ContactType>(request.ContactInfo.Type, out var parsedType))
            {
                existingContactInfo.Type = parsedType;
            }
            else
            {
                return new BaseResponse<Guid>("Invalid contact type.");
            }

            _unitOfWork.ContactInfoRepository.UpdateAsync(existingContactInfo);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(existingContactInfo.Id);
        }
    }
}
