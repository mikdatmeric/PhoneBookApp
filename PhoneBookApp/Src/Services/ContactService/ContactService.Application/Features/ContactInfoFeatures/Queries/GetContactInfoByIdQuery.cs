using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Queries
{
    public class GetContactInfoByIdQuery : IRequest<BaseResponse<ContactInfoDto>>
    {
        public Guid Id { get; set; }

        public GetContactInfoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
