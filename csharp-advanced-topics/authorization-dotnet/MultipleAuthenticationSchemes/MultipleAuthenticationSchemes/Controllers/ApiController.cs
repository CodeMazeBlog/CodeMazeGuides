using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MultipleAuthenticationSchemes.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    [Authorize]
    [HttpGet("getWithAny")]
    public IActionResult GetWithAny()
    {
        return Ok(new { Message = $"Hello to Code Maze {GetUsername()}"});
    }

    [Authorize(AuthenticationSchemes = "SecondJwtScheme")]
    //[Authorize(Policy = "OnlySecondJwtScheme")]
    [HttpGet("getWithSecondJwt")]
    public IActionResult GetWithSecondJwt()
    {
        return Ok(new { Message = $"Hello to Code Maze {GetUsername()}" });
    }

    private string? GetUsername()
    {
        return HttpContext.User.Claims
            .Where(x => x.Type == ClaimTypes.Name)
            .Select(x => x.Value)
            .FirstOrDefault();
    }
}
