namespace ContactService.Application.DTOs
{
    public class CreateContactInfoCommandDto
    {
        public Guid PersonId { get; set; }
        public string Type { get; set; } // Telefon, Email, Lokasyon
        public string Content { get; set; }
    }
}
