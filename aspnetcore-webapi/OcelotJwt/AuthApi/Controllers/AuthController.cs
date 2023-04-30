using AuthApi.Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginModel user)
    {
        var loginResult = _jwtTokenService.GenerateAuthToken(user);

        return loginResult is null ? Unauthorized() : Ok(loginResult);

        if (loginResult is null)
        {
            return Unauthorized();
        }

        return Ok(loginResult);
    }
}
