using Microsoft.AspNetCore.Mvc;

namespace External.PaymentGateway.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> TryPayment([FromBody] PaymentDto payment)
    {
        await Task.Delay(1000);       
        return Ok(true);      
    }
}