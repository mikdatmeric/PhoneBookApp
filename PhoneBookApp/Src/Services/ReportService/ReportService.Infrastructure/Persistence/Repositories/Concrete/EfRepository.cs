using Microsoft.EntityFrameworkCore;
using ReportService.Infrastructure.Persistence.Contexts;
using ReportService.Infrastructure.Persistence.Repositories.Abstract;

namespace ReportService.Infrastructure.Persistence.Repositories.Concrete
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly ReportDbContext _context;

        public EfRepository(ReportDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
