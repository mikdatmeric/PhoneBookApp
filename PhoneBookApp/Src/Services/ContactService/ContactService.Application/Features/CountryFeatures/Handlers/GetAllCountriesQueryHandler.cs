using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.CountryFeatures.Queries;
using ContactService.Infrastructure.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.CountryFeatures.Handlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, BaseResponse<List<CountryDto>>>
    {
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(ContactDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<CountryDto>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _context.Countries.ToListAsync(cancellationToken);
            var countryDtos = _mapper.Map<List<CountryDto>>(countries);

            return new BaseResponse<List<CountryDto>>(countryDtos);
        }
    }
}
