
namespace ContactService.Infrastructure.Persistence.Repositories.Abstract.Base
{
    public interface IRepository<T> : ISelectable<T>, IInsertable<T>, IUpdatable<T>, IDeletable<T> where T : class
    {
    }
}
