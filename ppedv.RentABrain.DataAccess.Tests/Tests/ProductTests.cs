using ppedv.RentABrain.Model;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.DataAccess.Tests.Tests
{
    /// <summary>
    /// CRUD Tests: Create, Read, Update, Delete
    /// https://de.wikipedia.org/wiki/CRUD
    /// </summary>
    public class ProductTests : IDisposable
    {
        readonly TestDatabase _testDatabase = new TestDatabase();

        public RentABrainContext Context => _testDatabase.GetContext();

        public void Dispose()
        {
            _testDatabase.Dispose();
        }

        [Fact]
        public void Create_Product_ShouldAddProductToDatabase()
        {
            // Arrange
            var product = new Product { Name = "New Product", TimeSpan = new TimeSpan(1, 0, 0), CostPerHour = 1000m };

            // Act
            Context.Products.Add(product);
            Context.SaveChanges();

            // Assert
            var savedProduct = Context.Products.Single(p => p.Name == "New Product");
            Assert.NotNull(savedProduct);
            Assert.Equal("New Product", savedProduct.Name);
            Assert.Equal(new TimeSpan(1, 0, 0), savedProduct.TimeSpan);
            Assert.Equal(1000m, savedProduct.CostPerHour);
        }

        [Fact]
        public void Read_Product_ShouldReturnProductFromDatabase()
        {
            // Arrange
            var product = new Product { Name = "Read Product", TimeSpan = new TimeSpan(2, 0, 0), CostPerHour = 1500m };
            Context.Products.Add(product);
            Context.SaveChanges();

            // Act
            var savedProduct = Context.Products.Single(p => p.Name == "Read Product");

            // Assert
            Assert.NotNull(savedProduct);
            Assert.Equal("Read Product", savedProduct.Name);
            Assert.Equal(new TimeSpan(2, 0, 0), savedProduct.TimeSpan);
            Assert.Equal(1500m, savedProduct.CostPerHour);
        }

        [Fact]
        public void Update_Product_ShouldUpdateProductInDatabase()
        {
            // Arrange
            var product = new Product { Name = "Update Product", TimeSpan = new TimeSpan(3, 0, 0), CostPerHour = 2000m };
            Context.Products.Add(product);
            Context.SaveChanges();

            // Act
            product.Name = "Updated Product";
            product.TimeSpan = new TimeSpan(4, 0, 0);
            product.CostPerHour = 2500m;
            Context.SaveChanges();

            // Assert
            var updatedProduct = Context.Products.Single(p => p.Name == "Updated Product");
            Assert.NotNull(updatedProduct);
            Assert.Equal("Updated Product", updatedProduct.Name);
            Assert.Equal(new TimeSpan(4, 0, 0), updatedProduct.TimeSpan);
            Assert.Equal(2500m, updatedProduct.CostPerHour);
        }

        [Fact]
        public void Delete_Product_ShouldRemoveProductFromDatabase()
        {
            // Arrange
            var product = new Product { Name = "Delete Product", TimeSpan = new TimeSpan(5, 0, 0), CostPerHour = 3000m };
            Context.Products.Add(product);
            Context.SaveChanges();

            // Act
            Context.Products.Remove(product);
            Context.SaveChanges();

            // Assert
            var deletedProduct = Context.Products.SingleOrDefault(p => p.Name == "Delete Product");
            Assert.Null(deletedProduct);
        }
    }

}