using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.CountryFeatures.Queries;
using ContactService.Application.Services.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Services.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CountryService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<CountryDto>>> GetAllCountriesAsync()
        {
            var query = new GetAllCountriesQuery();
            return await _mediator.Send(query);
        }

        public async Task<BaseResponse<CountryDto>> GetCountryByIdAsync(Guid id)
        {
            var query = new GetCountryByIdQuery(id);
            return await _mediator.Send(query);
        }
    }


}
