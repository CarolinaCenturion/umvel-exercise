using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Models
{
    public class Concept
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
