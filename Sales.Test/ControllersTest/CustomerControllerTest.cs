using Sales.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.ServiceInterfaces;
using Moq;
using Sales.Test.MockData;
using FluentAssertions;

namespace Sales.Test.ControllersTest
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task GetAllCustomers_ShouldReturn200Status()
        {
            /// Arrange
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(_ => _.GetAllCustomers()).Returns(CustomerMockData.GetCustomers());
            var sut = new CustomerController(customerService.Object);

            /// Act
            var result = (OkObjectResult)sut.GetAllCustomers();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateCustomer_ShouldReturn200Status()
        {
            /// Arrange
            var customerService = new Mock<ICustomerService>();
            var newCustomer = CustomerMockData.NewCustomer();
            var sut = new CustomerController(customerService.Object);

            /// Act
            var result = (OkResult)sut.CreateCustomer(newCustomer);


            /// Assert
            result.StatusCode.Should().Be(200);
            customerService.Verify(_ => _.CreateCustomer(newCustomer), Times.Exactly(1));
        }
    }
}