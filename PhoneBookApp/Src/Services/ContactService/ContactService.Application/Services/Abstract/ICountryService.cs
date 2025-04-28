using ContactService.Application.DTOs;
using Shared.BaseResponses.Response;

namespace ContactService.Application.Services.Abstract
{
    public interface ICountryService
    {
        Task<BaseResponse<List<CountryDto>>> GetAllCountriesAsync();
        Task<BaseResponse<CountryDto>> GetCountryByIdAsync(Guid id);
        bool CheckCountryExists(Guid id);
    }
}
