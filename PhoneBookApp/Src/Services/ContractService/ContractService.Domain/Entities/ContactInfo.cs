using ContractService.Domain.Common;
using static ContractService.Domain.Enums.Enums;

namespace ContractService.Domain.Entities
{
    public class ContactInfo : BaseEntity
    {
        public Guid PersonId { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }

        // Navigation Property
        public Person Person { get; set; }
    }

}
