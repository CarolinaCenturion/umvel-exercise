using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sales.API.Controllers;
using Sales.Domain.ServiceInterfaces;
using Sales.Test.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Test.ControllersTest
{
    public class SaleControllerTest
    {
        [Fact]
        public async Task GetAllSales_ShouldReturn200Status()
        {
            /// Arrange
            var saleService = new Mock<ISaleService>();
            saleService.Setup(_ => _.GetSalesByDateRange(DateTime.Now, DateTime.Now.AddDays(1))).Returns(SaleMockData.GetSalesByRangeDate());
            var sut = new SaleController(saleService.Object);

            /// Act
            var result = (OkObjectResult)sut.GetSalesByDateRange(DateTime.Now, DateTime.Now.AddDays(1));


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateSale_ShouldReturn200Status()
        {
            /// Arrange
            var saleService = new Mock<ISaleService>();
            var newSale = SaleMockData.NewSale();
            var sut = new SaleController(saleService.Object);

            /// Act
            var result = (OkResult)sut.CreateSale(newSale);


            /// Assert
            result.StatusCode.Should().Be(200);
            saleService.Verify(_ => _.CreateSale(newSale), Times.Exactly(1));
        }
    }
}
