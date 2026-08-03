using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Localization.Controllers;
public class CultureController : Controller
{
    [HttpPost]
    public IActionResult SetCulture(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
        );
        return LocalRedirect(returnUrl);
    }
}
