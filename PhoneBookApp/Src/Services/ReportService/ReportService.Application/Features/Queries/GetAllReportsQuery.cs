using MediatR;
using ReportService.Application.DTOs;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Features.Queries
{
    public class GetAllReportsQuery : IRequest<BaseResponse<List<ReportDto>>>
    {
    }
}
