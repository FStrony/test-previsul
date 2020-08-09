using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using test_previsul.Domain.Entities;

namespace test_previsul.Infra.Data.Context
{
    public class DmContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        private readonly static string DmContextConnectionString;

        static DmContext()
        {
            DmContextConnectionString = "Data Source=FERNANDOSANE2D7\\SQLEXPRESS01;Initial Catalog=previsul;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DmContextConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<CustomerAddress>().ToTable("CustomerAddresses");
            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Addresses)
                .WithOne(x => x.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entity in base.ChangeTracker.Entries())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("RegistrationDate").CurrentValue = DateTime.Now;
                    entity.Property("ModificationDate").CurrentValue = DateTime.Now;
                    if (Guid.Parse(entity.Property("Id").CurrentValue.ToString()) == Guid.Empty)
                    {
                        entity.Property("Id").CurrentValue = Guid.NewGuid();
                    }
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Property("RegistrationDate").IsModified = false;
                    entity.Property("ModificationDate").CurrentValue = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
