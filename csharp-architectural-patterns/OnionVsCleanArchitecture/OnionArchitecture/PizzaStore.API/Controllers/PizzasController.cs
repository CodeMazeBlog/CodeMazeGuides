using PizzaStore.Contracts;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Services.Abstractions;

namespace PizzaStore.Presentation.Controllers;

[ApiController]
[Route("api/pizzas")]
public class PizzasController(IPizzaService service) : ControllerBase
{
    private readonly IPizzaService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pizzas = await _service.GetAllAsync(cancellationToken);
        return Ok(pizzas);
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        await _service.PlaceOrderAsync(orderDto, cancellationToken);
        return Ok();
    }
}