using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Domain.Constants;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromForm] LoginModel model)
        {
            var result = await _userService.LoginAsync(model);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpDelete("DisableUser/{userId}")]
        [Authorize(Roles = RoleConstants.Admin)]
        public async Task<IActionResult> DisableUser(string userId)
        {
            await _userService.DisableUser(userId);
            return Ok();
        }
    }
}
