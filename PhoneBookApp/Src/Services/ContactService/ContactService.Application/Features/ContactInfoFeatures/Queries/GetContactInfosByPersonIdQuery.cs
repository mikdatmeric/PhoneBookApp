using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Queries
{
    public class GetContactInfosByPersonIdQuery : IRequest<BaseResponse<List<ContactInfoDto>>>
    {
        public Guid PersonId { get; set; }

        public GetContactInfosByPersonIdQuery(Guid personId)
        {
            PersonId = personId;
        }
    }
}
