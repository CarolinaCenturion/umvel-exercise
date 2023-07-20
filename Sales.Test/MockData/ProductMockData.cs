using Sales.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Test.MockData
{
    public class ProductMockData
    {
        public static List<CreateProductDTO> GetProducts()
        {
            return new List<CreateProductDTO> {
                new CreateProductDTO {
                    Name = "Computer",
                    Cost = 10000,
                    UnitPrice = "test1"
                },
                new CreateProductDTO {
                    Name = "Phone",
                    Cost = 5000,
                    UnitPrice = "test1"
                },
                new CreateProductDTO {
                    Name = "TV",
                    Cost = 8000,
                    UnitPrice = "test1"
                }

            };
        }

        public static CreateProductDTO NewProduct()
        {
            return new CreateProductDTO
            {
                Name = "Tablet",
                Cost = 5500,
                UnitPrice = "test4"
            };
        }
    }
}
