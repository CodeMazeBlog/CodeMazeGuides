using Microsoft.AspNetCore.Mvc;

namespace MapControllersVsMapControllerRoute.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}