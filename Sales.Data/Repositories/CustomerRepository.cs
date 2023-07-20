using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sales.Data.Context;
using Sales.Data.Core;
using Sales.Data.Interfaces;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Repositories
{
    public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        private readonly IMapper _mapper;
        public CustomerRepository(ApplicationDbContext applicationContext, IMapper mapper) : base(applicationContext)
        {
            _mapper = mapper;
        }

        public List<CustomerListDTO> GetCustomersAndSales()
        {
            return _context.Customers.ProjectTo<CustomerListDTO>(_mapper.ConfigurationProvider).ToList();
        }

        public CreateCustomerDTO GetCustomerDTOById(int id)
        {
            return _context.Customers.Where(c=>c.Id == id).ProjectTo<CreateCustomerDTO>(_mapper.ConfigurationProvider).FirstOrDefault();
        }


    }
}
