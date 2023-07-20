using Sales.API.Controllers;
using Sales.Domain.DTOs;
using Sales.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Test.MockData
{
    public class SaleMockData
    {
        public static List<SaleListDTO> GetSalesByRangeDate()
        {
            return new List<SaleListDTO> {
                new SaleListDTO {
                    Date = DateTime.Now,
                    Total = 10
                },
                new SaleListDTO {
                    Date = DateTime.Now,
                    Total = 20
                },
                new SaleListDTO {
                    Date = DateTime.Now,
                    Total = 30
                }

            };
        }

        public static CreateSaleDTO NewSale()
        {
            return new CreateSaleDTO
            {
               Date = DateTime.Now,
               Total = 0,
               CustomerId = 1
            };
        }
    }
}
