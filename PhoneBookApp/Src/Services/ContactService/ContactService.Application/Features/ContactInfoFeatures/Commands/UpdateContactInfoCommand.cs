using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Commands
{
    public class UpdateContactInfoCommand : IRequest<BaseResponse<Guid>>
    {
        public UpdateContactInfoCommandDto ContactInfo { get; set; }
    }

    

}
