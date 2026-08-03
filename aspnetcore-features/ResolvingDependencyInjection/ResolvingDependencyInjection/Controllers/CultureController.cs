using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ResolvingDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultureController : ControllerBase
    {
        [HttpOptions]
        public IActionResult SetCulture(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return new AcceptedResult();
        }
    }
}
