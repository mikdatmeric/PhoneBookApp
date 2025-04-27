using ContractService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContractService.Infrastructure.Persistence.Contexts
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
            // For example:
            // modelBuilder.Entity<Person>().ToTable("Persons");
            // modelBuilder.Entity<ContactInfo>().ToTable("ContactInfos");
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Persons");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);

                // Bir kişinin birden fazla iletişim bilgisi olabilir
                entity.HasMany(e => e.ContactInfos)
                      .WithOne(c => c.Person)
                      .HasForeignKey(c => c.PersonId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("ContactInfos");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Content).IsRequired().HasMaxLength(250);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.CountryName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PhoneCode).IsRequired().HasMaxLength(10);
            });

            // Seed Data - Başlangıçta 5 adet Country
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), CountryName = "Türkiye", PhoneCode = "+90" },
                new Country { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), CountryName = "ABD", PhoneCode = "+1" },
                new Country { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), CountryName = "Almanya", PhoneCode = "+49" },
                new Country { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), CountryName = "Fransa", PhoneCode = "+33" },
                new Country { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), CountryName = "Japonya", PhoneCode = "+81" }
            );
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Country> Countries
        {
            get; set;
        }
    }
}
