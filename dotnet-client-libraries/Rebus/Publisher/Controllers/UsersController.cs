using Microsoft.AspNetCore.Mvc;
using Publisher.Models;
using Rebus.Bus;
using Shared;

namespace Publisher.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private static List<User> _users = new();
    private readonly IBus _bus;

    public UsersController(IBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        if (_users.Any(u => string.Equals(u.Email, user.Email, StringComparison.OrdinalIgnoreCase)))
        {
            return BadRequest("User already exists");
        }

        _users.Add(user);

        await _bus.Publish(new UserCreatedEvent(user.Email));

        return Ok("User created");
    }
}
