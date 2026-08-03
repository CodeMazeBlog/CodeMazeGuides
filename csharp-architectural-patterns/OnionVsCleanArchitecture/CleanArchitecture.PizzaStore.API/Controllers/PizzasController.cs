using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.PizzaStore.Application.UseCases;

namespace CleanArchitecture.PizzaStore.API.Controllers;

[ApiController]
[Route("api/pizzas")]
public class PizzasController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetPizzasQuery(), cancellationToken));
    }

    [HttpPost("orders")]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand order, CancellationToken cancellationToken)
    {
        await mediator.Send(order, cancellationToken);
        return Ok();
    }
}