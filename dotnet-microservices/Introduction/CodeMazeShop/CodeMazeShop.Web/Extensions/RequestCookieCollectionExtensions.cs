using CodeMazeShop.Web.Models;

namespace CodeMazeShop.Web.Extensions;

public static class RequestCookieCollectionExtensions
{
    public static Guid GetCurrentCartId(this IRequestCookieCollection cookies, CookieSettings settings)
    {
        Guid.TryParse(cookies[settings.CartIdCookieName], out Guid cartId);
        return cartId;
    }
}
