using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commands.CreateToDo;
using ToDoApp.Application.Query.ToDoItem;

namespace ToDoApp.API.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class ToDoItemController(IMediator mediator) : ControllerBase
{        
    // GET: api/ToDoItem
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await mediator.Send(new ToDoItemQuery()));
    }

    // POST: api/ToDoItem
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateToDoItemCommand command)
    {            
        await mediator.Send(command);
        return Created();
    }
}
}
