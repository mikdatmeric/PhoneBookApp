using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.Repositories.Abstract;

namespace ReportService.Infrastructure.Persistence.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Report> ReportRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
