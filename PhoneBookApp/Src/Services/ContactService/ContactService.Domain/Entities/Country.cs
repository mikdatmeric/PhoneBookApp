namespace ContactService.Domain.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ülke ismi
        public string PhoneCode { get; set; } // Telefon kodu (+90 gibi)
    }

}
