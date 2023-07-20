using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.DTOs
{
    public class SaleListDTO
    {
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public CreateCustomerDTO? Customer { get; set; }
    }
}
