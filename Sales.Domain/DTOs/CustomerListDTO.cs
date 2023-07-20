using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.DTOs
{
    public class CustomerListDTO
    {
        public string Name { get; set; }
        public List<CreateSaleDTO> Sales { get; set; }
    }
}
