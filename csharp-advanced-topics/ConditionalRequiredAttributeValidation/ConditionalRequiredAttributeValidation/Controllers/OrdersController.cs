using ConditionalRequiredAttributeValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConditionalRequiredAttributeValidation.Controllers;

[Route("api/v1/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpPost("place-order")]
    public Task<IActionResult> PlaceOrder([FromBody] Order order)
    {
        if (!ModelState.IsValid)
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }

        return Task.FromResult<IActionResult>(Ok(order));
    }
}