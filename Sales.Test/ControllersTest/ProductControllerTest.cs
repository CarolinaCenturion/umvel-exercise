using Sales.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.ServiceInterfaces;
using Moq;
using Sales.Test.MockData;
using FluentAssertions;

namespace Sales.Test.ControllersTest
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task GetAllProducts_ShouldReturn200Status()
        {
            /// Arrange
            var productService = new Mock<IProductService>();
            productService.Setup(_ => _.GetAllProducts()).Returns(ProductMockData.GetProducts());
            var sut = new ProductController(productService.Object);

            /// Act
            var result = (OkObjectResult)sut.GetAllProducts();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateProduct_ShouldReturn200Status()
        {
            /// Arrange
            var productService = new Mock<IProductService>();
            var newProduct = ProductMockData.NewProduct();
            var sut = new ProductController(productService.Object);

            /// Act
            var result = (OkResult)sut.CreateProduct(newProduct);


            /// Assert
            result.StatusCode.Should().Be(200);
            productService.Verify(_ => _.CreateProduct(newProduct), Times.Exactly(1));
        }
    }
}

