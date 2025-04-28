using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Infrastructure.Persistence.Contexts
{
    public class ContactDbContextFactory : IDesignTimeDbContextFactory<ContactDbContext>
    {
        public ContactDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ContactDB;Username=postgres;Password=Mk.3225+-;SSL Mode=Disable;");

            return new ContactDbContext(optionsBuilder.Options);
        }
    }
}
