using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICountryRepository CountryRepository { get; }
        IPersonRepository PersonRepository { get; }
        IContactInfoRepository ContactInfoRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
