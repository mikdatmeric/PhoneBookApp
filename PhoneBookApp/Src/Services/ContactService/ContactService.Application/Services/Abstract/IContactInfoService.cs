using ContactService.Application.DTOs;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Services.Abstract
{
    public interface IContactInfoService
    {
        Task<BaseResponse<Guid>> CreateContactInfoAsync(CreateContactInfoCommandDto dto);
        Task<BaseResponse<Guid>> UpdateContactInfoAsync(UpdateContactInfoCommandDto dto);
        Task<BaseResponse<Guid>> DeleteContactInfoAsync(Guid contactInfoId);
        Task<BaseResponse<ContactInfoDto>> GetContactInfoByIdAsync(Guid contactInfoId);
        Task<BaseResponse<List<ContactInfoDto>>> GetContactInfosByPersonIdAsync(Guid personId);
    }
}
