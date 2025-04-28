using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ContactDbContext context) : base(context)
        {
        }

    }

}
