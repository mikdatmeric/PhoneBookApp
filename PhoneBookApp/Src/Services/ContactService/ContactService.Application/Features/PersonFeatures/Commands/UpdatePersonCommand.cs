using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Features.PersonFeatures.Commands
{
    public class UpdatePersonCommand : IRequest<BaseResponse<Guid>>
    {
        public UpdatePersonCommandDto Person { get; set; }
    }
}
