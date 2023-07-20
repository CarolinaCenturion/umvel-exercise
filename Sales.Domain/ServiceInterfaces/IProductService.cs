using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Domain.DTOs;


namespace Sales.Domain.ServiceInterfaces
{
    public interface IProductService
    {
        void CreateProduct(CreateProductDTO product);
        List<CreateProductDTO> GetAllProducts();
        CreateProductDTO GetProductById(int id);
    }
}
