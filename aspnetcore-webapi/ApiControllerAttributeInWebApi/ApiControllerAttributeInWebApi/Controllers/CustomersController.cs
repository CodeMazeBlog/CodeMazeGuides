using ApiControllerAttributeInWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllerAttributeInWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCustomersById(int id)
        {
            var customer = new Customer();

            if (!customer.IsActive)
                return ValidationProblem(); // Do not use BadRequest()

            return Ok(customer);
        }
        
        [HttpPost]
        public IActionResult PostCustomer(Customer product)
        {
            // Omitted data access code

            return Ok();
        }
    }
}