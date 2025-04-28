using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Commands
{
    public class CreatePersonCommand : IRequest<BaseResponse<Guid>>
    {
        public CreatePersonCommandDto Person { get; set; }
    }
}
