using Microsoft.EntityFrameworkCore;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.DataAccess.Data
{
    public class Seed
    {
        public const string ConnectionString = "Server=(localdb)\\SWArch250123;Database=RentABrain;Trusted_Connection=True;MultipleActiveResultSets=true";

        public const int Product3Id = 3;
        public const string Product3Name = "Swing-By Manöver";
        public const decimal Product3CostPerHour = 2000m;
        public const decimal Product3TotalCost = 6000m;
        public static readonly TimeSpan Product3Timespan = new TimeSpan(3, 0, 0);

        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Bugs Bunny", Email = "bugs.bunny@example.com" },
                new Customer { Id = 2, Name = "Daffy Duck", Email = "daffy.duck@example.com" },
                new Customer { Id = 3, Name = "Elmer Fudd", Email = "elmer.fudd@example.com" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Quantum Computing", TimeSpan = new TimeSpan(1, 0, 0), CostPerHour = 1000m },
                new Product { Id = 2, Name = "AI Optimization", TimeSpan = new TimeSpan(2, 0, 0), CostPerHour = 1500m },
                new Product { Id = Product3Id, Name = Product3Name, TimeSpan = Product3Timespan, CostPerHour = Product3CostPerHour }
            );

            // Seed Brains
            modelBuilder.Entity<Brain>().HasData(
                new Brain { Id = 1, ProductId = 1, PowerConsumption = 100, OperationsPerMinute = 10000, Location = "Bahama Islands" },
                new Brain { Id = 2, ProductId = 1, PowerConsumption = 110, OperationsPerMinute = 11000, Location = "Silicon Valley" },
                new Brain { Id = 3, ProductId = 1, PowerConsumption = 120, OperationsPerMinute = 12000, Location = "Tokyo" },
                new Brain { Id = 4, ProductId = 2, PowerConsumption = 200, OperationsPerMinute = 20000, Location = "New York" },
                new Brain { Id = 5, ProductId = 2, PowerConsumption = 210, OperationsPerMinute = 21000, Location = "London" },
                new Brain { Id = 6, ProductId = 2, PowerConsumption = 220, OperationsPerMinute = 22000, Location = "Berlin" },
                new Brain { Id = 7, ProductId = 3, PowerConsumption = 300, OperationsPerMinute = 30000, Location = "Paris" },
                new Brain { Id = 8, ProductId = 3, PowerConsumption = 310, OperationsPerMinute = 31000, Location = "Sydney" },
                new Brain { Id = 9, ProductId = 3, PowerConsumption = 320, OperationsPerMinute = 32000, Location = "Cape Town" },
                new Brain { Id = 10, ProductId = 3, PowerConsumption = 330, OperationsPerMinute = 33000, Location = "Rio de Janeiro" }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, ProductId = 1, OrderDate = new DateTime(2023, 1, 1), Quantity = 10 },
                new Order { Id = 2, CustomerId = 1, ProductId = 2, OrderDate = new DateTime(2023, 2, 1), Quantity = 20 },
                new Order { Id = 3, CustomerId = 1, ProductId = 3, OrderDate = new DateTime(2023, 3, 1), Quantity = 30 }
            );
        }
    }

}
