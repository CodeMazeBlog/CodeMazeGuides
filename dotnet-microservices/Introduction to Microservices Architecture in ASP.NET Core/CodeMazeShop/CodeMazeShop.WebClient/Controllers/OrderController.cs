using CodeMazeShop.WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeShop.WebClient.Controllers;

public class OrderController : Controller
{
    
    private readonly CookieSettings _cookieSettings;

    public OrderController(CookieSettings cookieSettings)
    {
        
        _cookieSettings = cookieSettings;
    }

    public IActionResult Index()
    {      
        return View(new OrderViewModel());
    }
}
