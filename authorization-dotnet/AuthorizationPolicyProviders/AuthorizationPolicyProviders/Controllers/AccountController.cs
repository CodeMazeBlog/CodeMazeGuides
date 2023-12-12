using System.Security.Claims;
using AuthorizationPolicyProviders.Authentication;
using AuthorizationPolicyProviders.HttpModels;
using AuthorizationPolicyProviders.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationPolicyProviders.Controllers;

public class AccountController : Controller
{
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn([FromForm] SignInRequest request)
    {
        if (request.LoyaltyPoints < 0 || !Enum.TryParse<MembershipTier>(request.MembershipTier, out var membershipTier))
            return View();

        var claims = new List<Claim>()
        {
            new(ClaimTypeConstants.LoyaltyPoints, request.LoyaltyPoints.ToString()),
            new(ClaimTypeConstants.MembershipTier, membershipTier.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return SignIn(
            new ClaimsPrincipal(identity),
            new AuthenticationProperties() { RedirectUri = "/" },
            CookieAuthenticationDefaults.AuthenticationScheme
        );
    }

    public new IActionResult SignOut()
    {
        return SignOut(new AuthenticationProperties() { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
