using Sales.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Test.MockData
{
    public class CustomerMockData
    {
        public static List<CustomerListDTO> GetCustomers()
        {
            return new List<CustomerListDTO> {
                new CustomerListDTO {
                    Name = "Sara Marquez"
                },
                new CustomerListDTO {
                    Name = "Isaac Sanchez"
                },
                new CustomerListDTO {
                    Name = "Luz Centurion"
                }
            };
        }

        public static CreateCustomerDTO NewCustomer()
        {
            return new CreateCustomerDTO{ Name = "Sara Marquez" };
        }
    }
}
