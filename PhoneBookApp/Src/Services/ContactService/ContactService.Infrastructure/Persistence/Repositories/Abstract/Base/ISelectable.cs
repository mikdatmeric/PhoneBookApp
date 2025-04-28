using System.Linq.Expressions;

namespace ContactService.Infrastructure.Persistence.Repositories.Abstract.Base
{
    public interface ISelectable<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
