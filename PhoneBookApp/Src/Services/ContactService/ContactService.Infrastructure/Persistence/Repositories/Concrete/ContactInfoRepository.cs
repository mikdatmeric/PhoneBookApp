using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class ContactInfoRepository : RepositoryBase<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(ContactDbContext context) : base(context)
        {
        }
    }

}
