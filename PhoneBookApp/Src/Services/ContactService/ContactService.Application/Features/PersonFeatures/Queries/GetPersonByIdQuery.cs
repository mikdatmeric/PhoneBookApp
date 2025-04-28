using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Queries
{
    public class GetPersonByIdQuery : IRequest<BaseResponse<PersonDetailDto>>
    {
        public Guid PersonId { get; set; }

        public GetPersonByIdQuery(Guid personId)
        {
            PersonId = personId;
        }
    }
}
