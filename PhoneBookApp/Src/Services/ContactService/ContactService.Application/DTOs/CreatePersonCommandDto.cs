﻿namespace ContactService.Application.DTOs
{
    public class CreatePersonCommandDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public List<CreateContactInfoCommandDto> ContactInfos { get; set; } = new List<CreateContactInfoCommandDto>();
    }
}
