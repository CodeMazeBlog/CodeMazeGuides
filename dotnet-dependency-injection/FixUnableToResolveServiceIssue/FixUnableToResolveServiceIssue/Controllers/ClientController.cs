using FixUnableToResolveServiceIssue.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FixUnableToResolveServiceIssue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly UserService _userService;

        // The injected service in this constructor is invalid.
        // To solve this issue, replace UserService with IUserService.
        public ClientController(UserService userService) 
        {
            _userService = userService;
        }

        // Since the injected service is invalid, the get request will throw an InvalidOperationException.
        [HttpGet]
        public IActionResult Get()
        {
            var user = _userService.GetUser(); 
            return Ok(user);
        }
    }
}
