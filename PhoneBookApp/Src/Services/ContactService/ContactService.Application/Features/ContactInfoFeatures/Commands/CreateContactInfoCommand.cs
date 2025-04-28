using ContactService.Application.DTOs;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Commands
{
    public class CreateContactInfoCommand : IRequest<BaseResponse<Guid>>
    {
        public CreateContactInfoCommandDto ContactInfo { get; set; }
    }

}
