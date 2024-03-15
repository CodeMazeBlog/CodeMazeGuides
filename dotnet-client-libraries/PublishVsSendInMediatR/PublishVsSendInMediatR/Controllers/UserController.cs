using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublishVsSendInMediatR.Commands;
using PublishVsSendInMediatR.Events;

namespace PublishVsSendInMediatR.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand command)
        {
            int userId = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateUser), userId);
        }

        [HttpPost("notify")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> NotifyUser(UserCreatedEvent notification)
        {
            await _mediator.Publish(notification);

            return Ok();
        }
    }
}
