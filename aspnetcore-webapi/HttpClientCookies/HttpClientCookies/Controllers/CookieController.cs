using Microsoft.AspNetCore.Mvc;

namespace HttpClientCookies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookieController : ControllerBase
    {
        [HttpGet(nameof(GetCookie))]
        public IActionResult GetCookie()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddHours(1);
            options.Secure = true;
            options.Domain = "example.com";

            Response.Cookies.Append("SimpleCookie", "RHsMeXPsMK", options);

            Response.Cookies.Append("FavouriteColor", "Red", options);

            return Ok();
        }
    }
}
