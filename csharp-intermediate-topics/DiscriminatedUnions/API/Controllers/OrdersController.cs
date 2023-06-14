using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpPost]
    public IActionResult Post(Order order)
    {
        var placeOrderResult = _ordersService.PlaceOrder(order);

        return placeOrderResult.Match<IActionResult>(
            receipt => Ok(receipt),
            error => StatusCode(500, new { error = error.ToString() }));
    }

    [HttpGet("findProductById")]
    public IActionResult GetProductById(int id)
    {
        return Ok(_ordersService.FindProduct(id));
    }

    [HttpGet("findProductByName")]
    public IActionResult GetProductByName(string name)
    {
        return Ok(_ordersService.FindProduct(name));
    }
}