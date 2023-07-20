using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.DTOs
{
    public  class CreateProductDTO
    {
        public string Name { get; set; }

        public string UnitPrice { get; set; }

        public decimal Cost { get; set; }
    }
}
