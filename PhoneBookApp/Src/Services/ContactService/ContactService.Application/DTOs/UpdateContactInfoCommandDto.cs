namespace ContactService.Application.DTOs
{
    public class UpdateContactInfoCommandDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
