using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Domain.DTOs;


namespace Sales.Domain.ServiceInterfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(CreateCustomerDTO customer);
        List<CustomerListDTO> GetAllCustomers();
        CreateCustomerDTO GetCustomerById(int customerId);

    }
}
