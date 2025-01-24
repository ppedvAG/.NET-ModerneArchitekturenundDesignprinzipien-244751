using ppedv.RentABrain.DataAccess.Data;
using ppedv.RentABrain.DataAccess.Tests;
using ppedv.RentABrain.Logic.Services;
using ppedv.RentABrain.Model;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.Logic.Tests.Tests
{
    public class ProductServiceTest
    {
        private readonly TestDatabase _testDatabase = new();
        private RentABrainRepositoryAdapter<Product> _repo;

        public ProductServiceTest()
        {
            var context = _testDatabase.GetContext();
            _repo = new RentABrainRepositoryAdapter<Product>(context);
        }

        [Fact]
        public void GetMostExpensiveProduct_ShouldReturnMostExpensiveProduct()
        {
            // Arrange
            var productService = new ProductService(_repo);

            // Act
            var mostExpensiveProduct = productService.GetMostExpensiveProduct();

            // Assert
            Assert.NotNull(mostExpensiveProduct);
            Assert.Equal(Seed.Product3Id, mostExpensiveProduct.Id);
            Assert.Equal(Seed.Product3Name, mostExpensiveProduct.Name);
        }

        [Fact]
        public void GetTotalCost_ShouldReturnTotalCostOfProduct()
        {
            // Arrange
            var productService = new ProductService(_repo);

            // Act
            var totalCost = productService.GetTotalCost(Seed.Product3Id);

            // Assert
            Assert.Equal(Seed.Product3TotalCost, totalCost);
        }

        [Fact]
        public void GetTotalCost_ShouldReturnZeroIfProductNotFound()
        {
            // Arrange
            var productService = new ProductService(_repo);

            // Act
            var totalCost = productService.GetTotalCost(-1);

            // Assert
            Assert.Equal(0m, totalCost);
        }
    }
}