using ContactService.Application.DTOs;
using ContactService.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ContactService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactInfo([FromBody] CreateContactInfoCommandDto contactInfoDto)
        {
            var result = await _contactInfoService.CreateContactInfoAsync(contactInfoDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactInfo([FromBody] UpdateContactInfoCommandDto contactInfoDto)
        {
            var result = await _contactInfoService.UpdateContactInfoAsync(contactInfoDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInfo(Guid id)
        {
            var result = await _contactInfoService.DeleteContactInfoAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetContactInfosByPersonId(Guid personId)
        {
            var result = await _contactInfoService.GetContactInfosByPersonIdAsync(personId);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetContactInfoById(Guid id)
        {
            var result = await _contactInfoService.GetContactInfoByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
