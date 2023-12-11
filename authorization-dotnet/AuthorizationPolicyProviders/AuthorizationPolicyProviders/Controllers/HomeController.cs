using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicyProviders.Authorization.Attributes;

namespace AuthorizationPolicyProviders.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [LoyaltyAuthorize("PriorityCheckIn")]
    public IActionResult PriorityCheckIn()
    {
        return View();
    }
}
