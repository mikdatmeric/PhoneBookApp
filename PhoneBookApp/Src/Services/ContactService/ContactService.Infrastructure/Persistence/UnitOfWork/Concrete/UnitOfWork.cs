using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using ContactService.Infrastructure.Persistence.Repositories.Concrete;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;

namespace ContactService.Infrastructure.Persistence.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactDbContext _context;

        private IPersonRepository _personRepository;
        private IContactInfoRepository _contactInfoRepository;

        public UnitOfWork(ContactDbContext context)
        {
            _context = context;
        }

        public IPersonRepository PersonRepository =>
            _personRepository ??= new PersonRepository(_context);

        public IContactInfoRepository ContactInfoRepository =>
            _contactInfoRepository ??= new ContactInfoRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
