using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Commands
{
    public class DeletePersonCommand : IRequest<BaseResponse<Guid>>
    {
        public Guid PersonId { get; set; }

        public DeletePersonCommand(Guid personId)
        {
            PersonId = personId;
        }
    }
}
