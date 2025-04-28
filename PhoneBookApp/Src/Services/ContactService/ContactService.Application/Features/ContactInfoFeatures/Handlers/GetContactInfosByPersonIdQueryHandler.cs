using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.ContactInfoFeatures.Queries;
using ContactService.Infrastructure.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Handlers
{
    public class GetContactInfosByPersonIdQueryHandler : IRequestHandler<GetContactInfosByPersonIdQuery, BaseResponse<List<ContactInfoDto>>>
    {
        private readonly ContactDbContext _context;
        private readonly IMapper _mapper;

        public GetContactInfosByPersonIdQueryHandler(ContactDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ContactInfoDto>>> Handle(GetContactInfosByPersonIdQuery request, CancellationToken cancellationToken)
        {
            var contactInfos = await _context.ContactInfos
                .Where(x => x.PersonId == request.PersonId)
                .ToListAsync(cancellationToken);

            if (contactInfos == null || !contactInfos.Any())
            {
                return BaseResponse<List<ContactInfoDto>>.Fail("No contact info found for this person.");
            }

            var contactInfoDtos = _mapper.Map<List<ContactInfoDto>>(contactInfos);
            return new BaseResponse<List<ContactInfoDto>>(contactInfoDtos);
        }
    }
}
