using Microsoft.AspNetCore.Mvc;
namespace CallingActionFromAnotherController.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        return View();
    }

    public IActionResult GetProductById(int id)
    {
        ViewData["id"] = id;
        return View();
    }

    public bool IsProductAvailable(int productId)
    { 
        return true; 
    }
}