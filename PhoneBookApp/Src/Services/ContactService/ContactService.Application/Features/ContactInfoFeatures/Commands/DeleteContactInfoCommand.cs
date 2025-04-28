using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Commands
{
    public class DeleteContactInfoCommand : IRequest<BaseResponse<Guid>>
    {
        public Guid ContactInfoId { get; set; }

        public DeleteContactInfoCommand(Guid contactInfoId)
        {
            ContactInfoId = contactInfoId;
        }
    }

    

}
