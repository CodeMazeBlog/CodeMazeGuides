using OnionArchitecture.PizzaStore.Contracts;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.PizzaStore.Services.Abstractions;

namespace OnionArchitecture.PizzaStore.Presentation.Controllers;

[ApiController]
[Route("api/pizzas")]
public class PizzasController(IPizzaService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pizzas = await service.GetAllAsync(cancellationToken);
        return Ok(pizzas);
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto, CancellationToken cancellationToken)
    {
        await service.PlaceOrderAsync(orderDto, cancellationToken);
        return Ok();
    }
}