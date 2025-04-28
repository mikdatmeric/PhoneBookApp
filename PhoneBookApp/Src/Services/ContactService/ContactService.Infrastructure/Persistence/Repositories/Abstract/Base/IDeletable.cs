namespace ContactService.Infrastructure.Persistence.Repositories.Abstract.Base
{
    public interface IDeletable<T> where T : class
    {
        Task DeleteAsync(T entity);
    }
}
