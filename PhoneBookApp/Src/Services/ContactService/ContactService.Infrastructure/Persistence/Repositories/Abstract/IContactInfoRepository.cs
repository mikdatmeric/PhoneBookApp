using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Repositories.Abstract.Base;

namespace ContactService.Infrastructure.Persistence.Repositories.Abstract
{
    public interface IContactInfoRepository : IRepository<ContactInfo>
    {

    }
}
