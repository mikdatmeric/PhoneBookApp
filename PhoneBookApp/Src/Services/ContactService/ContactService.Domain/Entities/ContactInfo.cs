using static ContactService.Domain.Enums.Enums;

namespace ContactService.Domain.Entities
{
    public class ContactInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Kişinin iletişim bilgisi için benzersiz kimlik
        public Guid PersonId { get; set; } // Kime ait?

        public ContactType Type { get; set; } // Telefon, Email, Lokasyon
        public string Content { get; set; } // Bilginin içeriği (örneğin tel numarası)

        // Navigation Property
        public Person Person { get; set; }
    }

}
