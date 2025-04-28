using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.CountryFeatures.Queries
{
    public class GetAllCountriesQuery : IRequest<BaseResponse<List<CountryDto>>>
    {
    }
}
