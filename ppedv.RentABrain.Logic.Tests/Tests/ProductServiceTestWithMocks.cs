using Moq;
using ppedv.RentABrain.Logic.Services;
using ppedv.RentABrain.Model.Contracts;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Logic.Tests.Tests
{
    public class ProductServiceTestsWithMocks
    {
        [Fact]
        public void GetMostExpensiveProduct_ShouldReturnMostExpensiveProduct()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", TimeSpan = new TimeSpan(1, 0, 0), CostPerHour = 1000m },
                new Product { Id = 2, Name = "Product 2", TimeSpan = new TimeSpan(2, 0, 0), CostPerHour = 1500m },
                new Product { Id = 3, Name = "Product 3", TimeSpan = new TimeSpan(3, 0, 0), CostPerHour = 2000m }
            };

            var mockRepository = new Mock<IRepository<Product>>();
            mockRepository.Setup(repo => repo.Query()).Returns(products.AsQueryable());

            var productService = new ProductService(mockRepository.Object);

            // Act
            var mostExpensiveProduct = productService.GetMostExpensiveProduct();

            // Assert
            Assert.NotNull(mostExpensiveProduct);
            Assert.Equal(3, mostExpensiveProduct.Id);
            Assert.Equal("Product 3", mostExpensiveProduct.Name);
        }

        [Fact]
        public void GetTotalCost_ShouldReturnTotalCostOfProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1", TimeSpan = new TimeSpan(1, 0, 0), CostPerHour = 1000m };

            var mockRepository = new Mock<IRepository<Product>>();
            mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(product);

            var productService = new ProductService(mockRepository.Object);

            // Act
            var totalCost = productService.GetTotalCost(1);

            // Assert
            Assert.Equal(1000m, totalCost);
        }

        [Fact]
        public void GetTotalCost_ShouldReturnZeroIfProductNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            mockRepository.Setup(repo => repo.GetById(1)).ReturnsAsync((Product)null);

            var productService = new ProductService(mockRepository.Object);

            // Act
            var totalCost = productService.GetTotalCost(1);

            // Assert
            Assert.Equal(0m, totalCost);
        }
    }

}
