namespace ContactService.Application.DTOs
{
    public class ContactInfoDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } // Enum değeri string olarak dönecek
        public string Content { get; set; }
    }
}
