using ContractService.Domain.Common;

namespace ContractService.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        // Navigation Property
        public ICollection<ContactInfo> ContactInfos { get; set; }
    }

}
