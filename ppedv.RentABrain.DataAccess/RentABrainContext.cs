using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ppedv.RentABrain.DataAccess.Data;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Model
{
    // DbContext for Entity Framework Core
    public class RentABrainContext : DbContext
    {
        public string ConnectionString { get; init; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brain> Brains { get; set; }

        public RentABrainContext()
        {
#if DEBUG
            ConnectionString = Seed.ConnectionString;
#endif       
        }

        public RentABrainContext(DbContextOptions<RentABrainContext> options) : base(options)
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Brains)
                .WithOne(b => b.Product)
                .HasForeignKey(b => b.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

            Seed.SeedData(modelBuilder);
        }
    }

}
