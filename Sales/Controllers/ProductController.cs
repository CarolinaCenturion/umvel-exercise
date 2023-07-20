using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Models;
using Sales.Domain.ServiceInterfaces;
using Sales.Domain.DTOs;


namespace Sales.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO product)
        {
            try
            {
                _productService.CreateProduct(product);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            try
            {
               return Ok(_productService.GetProductById(id));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
