using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ContactDbContext _context;

        public CountryRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetByIdAsync(Guid id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public IQueryable<Country> GetAllQueryable()
        {
            return _context.Countries.AsQueryable();
        }

        public async Task<IEnumerable<Country>> FindAsync(Expression<Func<Country, bool>> predicate)
        {
            return await _context.Countries.Where(predicate).ToListAsync();
        }
    }

}
