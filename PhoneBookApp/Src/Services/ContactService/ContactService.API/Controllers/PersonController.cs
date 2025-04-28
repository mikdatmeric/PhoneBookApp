using ContactService.Application.DTOs;
using ContactService.Application.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonCommandDto personDto)
        {
            var result = await _personService.CreatePersonAsync(personDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommandDto personDto)
        {
            var result = await _personService.UpdatePersonAsync(personDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var result = await _personService.DeletePersonAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _personService.GetAllPersonsAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var result = await _personService.GetPersonByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
