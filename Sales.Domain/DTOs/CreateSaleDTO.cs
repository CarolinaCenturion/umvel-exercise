using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.DTOs
{
    public class CreateSaleDTO
    {
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
    }
}
