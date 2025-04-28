namespace ContactService.Infrastructure.Persistence.Repositories.Abstract.Base
{
    public interface IUpdatable<T> where T : class
    {
        Task UpdateAsync(T entity);
    }
}
