using Sales.Data.Core;
using Sales.Data.Interfaces;
using Sales.Data.Repositories;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using Sales.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Services
{

    public  class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRespository)
        {
            _customerRepository = customerRespository;
        }

        public void CreateCustomer(CreateCustomerDTO customer)
        {
            var customerModel = GM<CreateCustomerDTO, Customer>.MapObject(customer);
            _customerRepository.Create(customerModel, true);
        }

        public List<CustomerListDTO> GetAllCustomers()
        {
            return _customerRepository.GetCustomersAndSales();
        }

        public CreateCustomerDTO GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerDTOById(customerId);
        }
    }
}
