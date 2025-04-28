using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.CountryFeatures.Queries
{
    public class GetCountryByIdQuery : IRequest<BaseResponse<CountryDto>>
    {
        public Guid Id { get; set; }

        public GetCountryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
