using Microsoft.AspNetCore.Mvc;

namespace MapControllersVsMapControllerRoute.Controllers;

[Route("Customers")]
public class CustomersController : Controller
{
    [Route("")]
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Info/{id}")]
    public IActionResult Detail(int id)
    {
        return View();
    }

    [Route("Order")]
    [Route("Customer/Order")]
    public IActionResult Order()
    {
        return View();
    }
    
    [HttpGet("/Special")]
    public IActionResult SpecialRoute()
    {
        return View();
    }
}