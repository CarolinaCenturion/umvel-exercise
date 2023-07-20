using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.DTOs;
using Sales.Domain.Models;
using Sales.Domain.ServiceInterfaces;

namespace Sales.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDTO customer)
        {
            try
            {
                _customerService.CreateCustomer(customer);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCustomerById(int customerId)
        {
            try
            {
                return Ok(_customerService.GetCustomerById(customerId));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
