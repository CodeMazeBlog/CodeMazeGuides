using CodeMazeShop.Web.Models;
using CodeMazeShop.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeShop.Web.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly CookieSettings _cookieSettings;

    public OrderController(IOrderService orderService, CookieSettings cookieSettings)
    {
        _orderService = orderService;
        _cookieSettings = cookieSettings;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _orderService.GetOrdersForUser(_cookieSettings.UserId);

        return View(new OrderViewModel { Orders = orders });
    }
}
