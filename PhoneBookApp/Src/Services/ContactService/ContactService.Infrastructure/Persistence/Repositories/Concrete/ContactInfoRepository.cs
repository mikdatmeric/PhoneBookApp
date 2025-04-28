using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Contexts;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly ContactDbContext _context;

        public ContactInfoRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ContactInfo entity)
        {
            await _context.ContactInfos.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<ContactInfo> entities)
        {
            await _context.ContactInfos.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(ContactInfo entity)
        {
            _context.ContactInfos.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.ContactInfos.ToListAsync();
        }

        public async Task<ContactInfo> GetByIdAsync(Guid id)
        {
            return await _context.ContactInfos.FindAsync(id);
        }

        public IQueryable<ContactInfo> GetAllQueryable()
        {
            return _context.ContactInfos.AsQueryable();
        }

        public async Task<IEnumerable<ContactInfo>> FindAsync(Expression<Func<ContactInfo, bool>> predicate)
        {
            return await _context.ContactInfos.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(ContactInfo entity)
        {
            _context.ContactInfos.Update(entity);
            await Task.CompletedTask;
        }
    }

}
