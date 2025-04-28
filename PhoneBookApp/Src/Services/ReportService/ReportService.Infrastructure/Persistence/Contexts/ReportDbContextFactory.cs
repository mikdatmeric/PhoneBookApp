using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ReportService.Infrastructure.Persistence.Contexts
{
    public class ReportDbContextFactory : IDesignTimeDbContextFactory<ReportDbContext>
    {
        public ReportDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReportDbContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ReportDB;Username=postgres;Password=Mk.3225+-;SSL Mode=Disable;");

            return new ReportDbContext(optionsBuilder.Options);
        }
    }
}
