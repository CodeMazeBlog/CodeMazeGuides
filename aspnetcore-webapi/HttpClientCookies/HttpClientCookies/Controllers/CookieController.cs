using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HttpClientCookies.Controllers;

[ApiController]
[Route("[controller]")]
public class CookieController : ControllerBase
{
    [HttpGet(nameof(GetCookie))]
    public IActionResult GetCookie()
    {

        var options = new CookieOptions();
        options.Expires = DateTime.Now.AddHours(1);
        options.Secure = true;
        options.Domain = "example.com";

        Response.Cookies.Append("SimpleCookie", "RHsMeXPsMK", options);

        Response.Cookies.Append("FavouriteColor", "Red", options);

        return Ok();
    }

    [HttpPost(nameof(Authenticate))]
    public async Task<IActionResult> Authenticate(string input)
    {
        var baseAddress = new Uri("https://localhost:7222/Cookie/");
        var cookieContainer = new CookieContainer();
        using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
        using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
        {

            cookieContainer.Add(baseAddress, new Cookie("AuthCookie", input));
            var result = await client.GetAsync($"ValidateAuthenticationCookie");

            if (result.IsSuccessStatusCode)
            {
                return Ok("Cookie validated");
            }
        }

        return BadRequest("Invalid input");
    }

    [HttpGet(nameof(ValidateAuthenticationCookie))]
    public IActionResult ValidateAuthenticationCookie()
    {
        var authCookie = Request.Cookies.FirstOrDefault(c => c.Key.Equals("AuthCookie"));

        if (authCookie.Value.Equals("secretKey"))
        {
            return Ok("Valid cookie");

        }

        return BadRequest();
    }
}

