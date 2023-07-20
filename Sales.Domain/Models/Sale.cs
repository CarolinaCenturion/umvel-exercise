using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sales.Domain.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
