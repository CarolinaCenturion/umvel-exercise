using Sales.Data.Core;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Data.Interfaces
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        List<CreateProductDTO> GetProductsDTO();
        CreateProductDTO GetProductByIdDTO(int id);
    }
}
