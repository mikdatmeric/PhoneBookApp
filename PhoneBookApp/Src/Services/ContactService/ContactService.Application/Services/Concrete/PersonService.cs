using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Application.Features.PersonFeatures.Queries;
using ContactService.Application.Services.Abstract;
using MediatR;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Application.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Guid>> CreatePersonAsync(CreatePersonCommandDto dto)
        {
            var command = new CreatePersonCommand { Person = dto };
            return await _mediator.Send(command);
        }

        public async Task<BaseResponse<Guid>> UpdatePersonAsync(UpdatePersonCommandDto dto)
        {
            var command = new UpdatePersonCommand { Person = dto };
            return await _mediator.Send(command);
        }

        public async Task<BaseResponse<Guid>> DeletePersonAsync(Guid personId)
        {
            var command = new DeletePersonCommand(personId);
            return await _mediator.Send(command);
        }

        public async Task<BaseResponse<List<PersonDto>>> GetAllPersonsAsync()
        {
            var query = new GetAllPersonsQuery();
            return await _mediator.Send(query);
        }

        public async Task<BaseResponse<PersonDetailDto>> GetPersonByIdAsync(Guid personId)
        {
            var query = new GetPersonByIdQuery(personId);
            return await _mediator.Send(query);
        }
    }
}
