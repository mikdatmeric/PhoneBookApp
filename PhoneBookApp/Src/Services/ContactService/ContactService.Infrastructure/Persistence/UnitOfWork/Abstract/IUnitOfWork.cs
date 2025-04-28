using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPersonRepository PersonRepository { get; }
        IContactInfoRepository ContactInfoRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
