using AutoMapper;
using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Handlers
{
    public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand, BaseResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateContactInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.ContactInfo.PersonId);
            if (person == null)
                return BaseResponse<Guid>.Fail("Person not found.");

            var contactInfoEntity = _mapper.Map<ContactInfo>(request.ContactInfo);

            await _unitOfWork.ContactInfoRepository.AddAsync(contactInfoEntity);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Guid>(contactInfoEntity.Id);
        }
    }
}
