using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Application.Features.ContactInfoFeatures.Queries;
using ContactService.Application.Services.Abstract;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Services.Concrete
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactInfoService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> CreateContactInfoAsync(CreateContactInfoCommandDto dto)
        {
            var command = new CreateContactInfoCommand { ContactInfo = dto };
            return await _mediator.Send(command);
        }

        public async Task<BaseResponse<Guid>> UpdateContactInfoAsync(UpdateContactInfoCommandDto dto)
        {
            var command = new UpdateContactInfoCommand { ContactInfo = dto };
            return await _mediator.Send(command);
        }

        public async Task<BaseResponse<Guid>> DeleteContactInfoAsync(Guid contactInfoId)
        {
            var command = new DeleteContactInfoCommand(contactInfoId);
            return await _mediator.Send(command);
        }
        public async Task<BaseResponse<ContactInfoDto>> GetContactInfoByIdAsync(Guid contactInfoId)
        {
            var query = new GetContactInfoByIdQuery(contactInfoId);
            return await _mediator.Send(query);
        }
        public async Task<BaseResponse<List<ContactInfoDto>>> GetContactInfosByPersonIdAsync(Guid personId)
        {
            var query = new GetContactInfosByPersonIdQuery(personId);
            return await _mediator.Send(query);
        }
    }
}
