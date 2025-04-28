

namespace ContactService.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } // İsim
        public string LastName { get; set; } // Soyisim
        public string Company { get; set; } // Firma Bilgisi

        // Navigation Property
        public ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>(); // Kişinin iletişim bilgileri
    }

}
