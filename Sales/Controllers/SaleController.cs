using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using Sales.Domain.ServiceInterfaces;

namespace Sales.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult CreateSale(CreateSaleDTO sale)
        {
            try
            {
                _saleService.CreateSale(sale);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
               return Ok(_saleService.GetSalesByDateRange(startDate, endDate));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
