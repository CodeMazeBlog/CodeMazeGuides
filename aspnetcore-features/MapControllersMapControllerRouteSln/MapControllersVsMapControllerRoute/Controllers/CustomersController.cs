using Microsoft.AspNetCore.Mvc;

namespace MapControllersVsMapControllerRoute.Controllers;

[Route("Customers")]
public class CustomersController : Controller
{
    [Route("")]
    [Route("Index")]
    public IActionResult Index()
    {
        return Ok();
    }

    [HttpGet("Info/{id}")]
    public IActionResult Detail(int id)
    {
        return Ok();
    }

    [Route("Order")]
    [Route("Customer/Order")]
    public IActionResult Order()
    {
        return Ok();
    }
    
    [HttpGet("/Special")]
    public IActionResult SpecialRoute()
    {
        return Ok();
    }
}