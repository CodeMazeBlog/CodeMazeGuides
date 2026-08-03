using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commands.CreateToDo;
using ToDoApp.Application.Queries.ToDoItem;

namespace ToDoApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await mediator.Send(new ToDoItemQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateToDoItemCommand command)
    {
        await mediator.Send(command);

        return Created();
    }
}
