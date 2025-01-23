using Microsoft.EntityFrameworkCore;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.DataAccess.Data
{
    public class Seed
    {
        public const string ConnectionString = "Server=(localdb)\\SWArch250123;Database=RentABrain;Trusted_Connection=True;MultipleActiveResultSets=true";

        public const string Customer1Id = "123e4567-e89b-12d3-a456-426614174001";
        public const string Customer2Id = "123e4567-e89b-12d3-a456-426614174002";
        public const string Customer3Id = "123e4567-e89b-12d3-a456-426614174003";

        public const string Product1Id = "123e4567-e89b-12d3-a456-426614174004";
        public const string Product2Id = "123e4567-e89b-12d3-a456-426614174005";
        public const string Product3Id = "123e4567-e89b-12d3-a456-426614174006";

        public const string Brain1Id = "123e4567-e89b-12d3-a456-426614174007";
        public const string Brain2Id = "123e4567-e89b-12d3-a456-426614174008";
        public const string Brain3Id = "123e4567-e89b-12d3-a456-426614174009";
        public const string Brain4Id = "123e4567-e89b-12d3-a456-426614174010";
        public const string Brain5Id = "123e4567-e89b-12d3-a456-426614174011";
        public const string Brain6Id = "123e4567-e89b-12d3-a456-426614174012";
        public const string Brain7Id = "123e4567-e89b-12d3-a456-426614174013";
        public const string Brain8Id = "123e4567-e89b-12d3-a456-426614174014";
        public const string Brain9Id = "123e4567-e89b-12d3-a456-426614174015";
        public const string Brain10Id = "123e4567-e89b-12d3-a456-426614174016";

        public const string Order1Id = "123e4567-e89b-12d3-a456-426614174017";
        public const string Order2Id = "123e4567-e89b-12d3-a456-426614174018";
        public const string Order3Id = "123e4567-e89b-12d3-a456-426614174019";

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
                new Product { Id = 3, Name = "Swing-By Manöver", TimeSpan = new TimeSpan(3, 0, 0), CostPerHour = 2000m }
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
