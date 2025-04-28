using ContactService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Infrastructure.Persistence.Contexts
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person Entity
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Persons");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Company)
                    .HasMaxLength(150);

                // Relation: Person -> ContactInfos (One to Many)
                entity.HasMany(e => e.ContactInfos)
                      .WithOne(c => c.Person)
                      .HasForeignKey(c => c.PersonId)
                      .OnDelete(DeleteBehavior.Cascade); // Person silinince ContactInfos da silinir
            });

            // ContactInfo Entity
            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("ContactInfos");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Type)
                    .IsRequired();
            });

            // Country Entity
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            // Seed Data: 5 Ülke
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Türkiye", PhoneCode = "+90" },
                new Country { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "ABD", PhoneCode = "+1" },
                new Country { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Almanya", PhoneCode = "+49" },
                new Country { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Fransa", PhoneCode = "+33" },
                new Country { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Japonya", PhoneCode = "+81" }
            );
        }
    }
}
