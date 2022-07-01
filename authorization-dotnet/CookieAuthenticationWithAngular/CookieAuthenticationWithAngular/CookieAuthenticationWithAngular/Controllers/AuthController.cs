using CookieAuthenticationWithAngular.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieAuthenticationWithAngular.Controllers;

[ApiController]
public class AuthController : Controller
{
    private List<User> users = new()
    {
        new("user1@test.com", "User 1", "user1"),
        new("user2@test.com", "User 2", "user2"),
    };

    [HttpPost]
    [Route("api/signin")]
    [AllowAnonymous]
    public async Task<Response> SignInAsync(SignInRequest signInRequest)
    {
        var user = users.FirstOrDefault(x => x.Email == signInRequest.Email &&
                                            x.Password == signInRequest.Password);

        if (user is null)
        {
            return new Response(false, "Invalid credentials.");
        }

        var claims = new List<Claim>
        {
            new Claim(type: ClaimTypes.Email, value: signInRequest.Email),
            new Claim(type: ClaimTypes.Name,value: user.Name)
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
        return new Response(true, "Signed in successfully");
    }

    [HttpGet]
    [Route("api/user")]
    [Authorize]
    public IActionResult GetUser()
    {
        var userClaims = User.Claims.Select(x => new UserClaim(x.Type, x.Value)).ToList();
        return Ok(userClaims);
    }

    [HttpGet]
    [Route("api/signout")]
    [Authorize]
    public async Task SignOutAsync()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
