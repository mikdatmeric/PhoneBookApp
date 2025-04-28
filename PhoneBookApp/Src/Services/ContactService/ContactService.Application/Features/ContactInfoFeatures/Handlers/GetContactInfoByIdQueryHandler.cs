using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.ContactInfoFeatures.Queries;
using ContactService.Infrastructure.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.ContactInfoFeatures.Handlers
{
    public partial class UpdateContactInfoCommandHandler
    {
        public class GetContactInfoByIdQueryHandler : IRequestHandler<GetContactInfoByIdQuery, BaseResponse<ContactInfoDto>>
        {
            private readonly ContactDbContext _context;
            private readonly IMapper _mapper;

            public GetContactInfoByIdQueryHandler(ContactDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BaseResponse<ContactInfoDto>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
            {
                var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (contactInfo == null)
                {
                    return new BaseResponse<ContactInfoDto>("ContactInfo not found.");
                }

                var contactInfoDto = _mapper.Map<ContactInfoDto>(contactInfo);
                return new BaseResponse<ContactInfoDto>(contactInfoDto);
            }
        }
    }
}
