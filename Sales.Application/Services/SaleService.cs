using Sales.Data.Core;
using Sales.Data.Interfaces;
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
    public class SaleService: ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICustomerRepository _customerRepository;

        public SaleService(ISaleRepository saleRepository, ICustomerRepository customerRepository)
        {
            _saleRepository = saleRepository;
            _customerRepository = customerRepository;
        }

        public void CreateSale(CreateSaleDTO sale)
        {
            var customer = _customerRepository.GetById(sale.CustomerId);
            var saleModel = GM<CreateSaleDTO, Sale>.MapObject(sale);
            if (customer != null)
            {
                saleModel.Customer = customer;
                _saleRepository.Create(saleModel, true);
            }
        }
        public List<SaleListDTO> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _saleRepository.GetSalesDTOByRangeDate(startDate, endDate);
        }
    }
}
