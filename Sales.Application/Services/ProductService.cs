using Sales.Data.Interfaces;
using Sales.Domain.Models;
using Sales.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Domain.DTOs;
using Sales.Data.Core;

namespace Sales.Application.Services
{
    public class ProductService: IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void CreateProduct(CreateProductDTO product) 
        {
            var productModel = GM<CreateProductDTO, Product>.MapObject(product);
            _productRepository.Create(productModel,true);
        }
        public List<CreateProductDTO> GetAllProducts()
        {
            return _productRepository.GetProductsDTO();
        }
        public CreateProductDTO GetProductById(int id)
        {
            return _productRepository.GetProductByIdDTO(id);
        }

    }
}
