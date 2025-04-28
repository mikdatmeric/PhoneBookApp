using ContactService.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _countryService.GetAllCountriesAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            var result = await _countryService.GetCountryByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
