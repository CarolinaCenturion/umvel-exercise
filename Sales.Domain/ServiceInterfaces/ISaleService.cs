using Sales.Domain.DTOs;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.ServiceInterfaces
{
    public interface ISaleService
    {
        void CreateSale(CreateSaleDTO sale);
        List<SaleListDTO> GetSalesByDateRange(DateTime startDate, DateTime endDate);
    }
}
