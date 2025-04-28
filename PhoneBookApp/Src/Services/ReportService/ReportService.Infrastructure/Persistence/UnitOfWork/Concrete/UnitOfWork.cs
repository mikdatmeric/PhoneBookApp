using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.Contexts;
using ReportService.Infrastructure.Persistence.Repositories.Abstract;
using ReportService.Infrastructure.Persistence.Repositories.Concrete;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Infrastructure.Persistence.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportDbContext _context;
        private readonly IRepository<Report> _reportRepository;

        public UnitOfWork(ReportDbContext context)
        {
            _context = context;
            _reportRepository = new EfRepository<Report>(_context);
        }

        public IRepository<Report> ReportRepository => _reportRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
