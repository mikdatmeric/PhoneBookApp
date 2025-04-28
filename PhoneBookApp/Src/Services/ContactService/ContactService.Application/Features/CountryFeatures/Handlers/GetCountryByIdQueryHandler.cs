using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.CountryFeatures.Queries;
using ContactService.Infrastructure.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.CountryFeatures.Handlers
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, BaseResponse<CountryDto>>
    {
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;

        public GetCountryByIdQueryHandler(ContactDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (country == null)
            {
                return BaseResponse<CountryDto>.Fail("Country not found.");
            }

            var countryDto = _mapper.Map<CountryDto>(country);
            return new BaseResponse<CountryDto>(countryDto);
        }
    }
}
