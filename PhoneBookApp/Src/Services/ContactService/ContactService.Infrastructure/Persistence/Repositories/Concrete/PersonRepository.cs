using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContactDbContext _context;

        public PersonRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person entity)
        {
            await _context.Persons.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<Person> entities)
        {
            await _context.Persons.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(Person entity)
        {
            _context.Persons.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public IQueryable<Person> GetAllQueryable()
        {
            return _context.Persons.AsQueryable();
        }

        public async Task<IEnumerable<Person>> FindAsync(Expression<Func<Person, bool>> predicate)
        {
            return await _context.Persons.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(Person entity)
        {
            _context.Persons.Update(entity);
            await Task.CompletedTask;
        }
    }

}
