using ContractService.Domain.Common;

namespace ContractService.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }    // Ülke adı
        public string PhoneCode { get; set; }       // Telefon kodu (Örneğin: +90)
    }

}
