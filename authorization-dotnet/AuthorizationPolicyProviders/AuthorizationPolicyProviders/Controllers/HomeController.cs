using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicyProviders.Authorization.Attributes;
using AuthorizationPolicyProviders.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [LoyaltyAuthorize(AuthorizationConstants.PriorityCheckIn)]
    public IActionResult PriorityCheckIn()
    {
        return View();
    }

    [Authorize(AuthorizationConstants.PriorityCheckInFull)]
    public IActionResult PriorityCheckInDefaltAuthorizeAttribute()
    {
        return View(nameof(PriorityCheckIn));
    }
}
