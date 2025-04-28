using ContactService.Application.DTOs;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Application.Services.Abstract
{
    public interface IPersonService
    {
        Task<BaseResponse<Guid>> CreatePersonAsync(CreatePersonCommandDto dto);
        Task<BaseResponse<Guid>> UpdatePersonAsync(UpdatePersonCommandDto dto);
        Task<BaseResponse<Guid>> DeletePersonAsync(Guid personId);
        Task<BaseResponse<List<PersonDto>>> GetAllPersonsAsync();
        Task<BaseResponse<PersonDetailDto>> GetPersonByIdAsync(Guid personId);
    }
}
