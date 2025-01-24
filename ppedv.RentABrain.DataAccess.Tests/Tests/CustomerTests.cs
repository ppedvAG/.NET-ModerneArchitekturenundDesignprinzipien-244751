using ppedv.RentABrain.Model;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.DataAccess.Tests.Tests
{
    public class CustomerTests : IDisposable
    {
        readonly TestDatabase _testDatabase = new TestDatabase();

        public RentABrainContext Context => _testDatabase.GetContext();

        public void Dispose()
        {
            _testDatabase.Dispose();
        }

        [Fact]
        public void Create_Customer_ShouldAddCustomerToDatabase()
        {
            // Arrange
            var customer = new Customer { Name = "New Customer", Email = "newcustomer@example.com" };

            // Act
            Context.Customers.Add(customer);
            Context.SaveChanges();

            // Assert
            var savedCustomer = Context.Customers.Single(c => c.Name == "New Customer");
            Assert.NotNull(savedCustomer);
            Assert.Equal("New Customer", savedCustomer.Name);
            Assert.Equal("newcustomer@example.com", savedCustomer.Email);
        }

        [Fact]
        public void Read_Customer_ShouldReturnCustomerFromDatabase()
        {
            // Arrange
            var customer = new Customer { Name = "Read Customer", Email = "readcustomer@example.com" };
            Context.Customers.Add(customer);
            Context.SaveChanges();

            // Act
            var savedCustomer = Context.Customers.Single(c => c.Name == "Read Customer");

            // Assert
            Assert.NotNull(savedCustomer);
            Assert.Equal("Read Customer", savedCustomer.Name);
            Assert.Equal("readcustomer@example.com", savedCustomer.Email);
        }

        [Fact]
        public void Update_Customer_ShouldUpdateCustomerInDatabase()
        {
            // Arrange
            var customer = new Customer { Name = "Update Customer", Email = "updatecustomer@example.com" };
            Context.Customers.Add(customer);
            Context.SaveChanges();

            // Act
            customer.Name = "Updated Customer";
            customer.Email = "updatedcustomer@example.com";
            Context.SaveChanges();

            // Assert
            var updatedCustomer = Context.Customers.Single(c => c.Name == "Updated Customer");
            Assert.NotNull(updatedCustomer);
            Assert.Equal("Updated Customer", updatedCustomer.Name);
            Assert.Equal("updatedcustomer@example.com", updatedCustomer.Email);
        }

        [Fact]
        public void Delete_Customer_ShouldRemoveCustomerFromDatabase()
        {
            // Arrange
            var customer = new Customer { Name = "Delete Customer", Email = "deletecustomer@example.com" };
            Context.Customers.Add(customer);
            Context.SaveChanges();

            // Act
            Context.Customers.Remove(customer);
            Context.SaveChanges();

            // Assert
            var deletedCustomer = Context.Customers.SingleOrDefault(c => c.Name == "Delete Customer");
            Assert.Null(deletedCustomer);
        }

    }

}