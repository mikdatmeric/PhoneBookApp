using ContactService.Application.DTOs;
using MediatR;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Application.Features.PersonFeatures.Queries
{
    public class GetAllPersonsQuery : IRequest<BaseResponse<List<PersonDto>>>
    {
    }
}
