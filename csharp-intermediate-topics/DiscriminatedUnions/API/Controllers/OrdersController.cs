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
        var getProductResult = _ordersService.FindProduct(id);

        return getProductResult.Match<IActionResult>(
            product => Ok(product),
            notFound => NotFound());
    }

    [HttpGet("findProductByName")]
    public IActionResult GetProductByName(string name)
    {
        var getProductResult = _ordersService.FindProduct(name);

        return getProductResult.Match<IActionResult>(
            product => Ok(product),
            notFound => NotFound());
    }
}