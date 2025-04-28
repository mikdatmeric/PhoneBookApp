namespace ContactService.Infrastructure.Persistence.Repositories.Abstract.Base
{
    public interface IInsertable<T> where T : class
    {
        Task AddAsync(T entity);
    }
}
