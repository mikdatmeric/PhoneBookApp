using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using ContactService.Infrastructure.Persistence.Repositories.Concrete;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;

namespace ContactService.Infrastructure.Persistence.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactDbContext _context;

        public ICountryRepository CountryRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IContactInfoRepository ContactInfoRepository { get; }

        public UnitOfWork(ContactDbContext context)
        {
            _context = context;
            CountryRepository = new CountryRepository(_context);
            PersonRepository = new PersonRepository(_context);
            ContactInfoRepository = new ContactInfoRepository(_context);
        }

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
