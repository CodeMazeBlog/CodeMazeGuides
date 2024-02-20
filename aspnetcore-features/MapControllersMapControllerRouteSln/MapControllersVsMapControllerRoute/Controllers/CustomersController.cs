using Microsoft.AspNetCore.Mvc;

namespace MapControllersVsMapControllerRoute.Controllers;

[Route("Customers")]
public class CustomersController : Controller
{
    [Route("")]
    [Route("Index")]
    public IActionResult Index()
    {
        return Ok("Customers Index");
    }

    [HttpGet("Info/{id}")]
    public IActionResult Detail(int id)
    {
        return Ok($"Customer {id} Info");
    }

    [Route("Order")]
    [Route("Customer/Order")]
    public IActionResult Order()
    {
        return Ok("Customers Order");
    }

    [HttpGet("/Special")]
    public IActionResult SpecialRoute()
    {
        return Ok("Customers SpecialRoute");
    }
}