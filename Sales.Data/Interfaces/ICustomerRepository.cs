using Sales.Data.Core;
using Sales.Data.Repositories;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        List<CustomerListDTO> GetCustomersAndSales();
        CreateCustomerDTO GetCustomerDTOById(int id);
    }
}
