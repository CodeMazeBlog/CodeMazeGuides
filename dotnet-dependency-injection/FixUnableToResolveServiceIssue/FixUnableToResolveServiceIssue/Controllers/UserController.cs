using FixUnableToResolveServiceIssue.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FixUnableToResolveServiceIssue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        // This dependency injection is valid.
        // However, the service is not registered in the dependency injection container. 
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        // Since the injected service is invalid, the get request will throw an InvalidOperationException.
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = _userService.GetUser();

            return Ok(user);
        }
    }
}
