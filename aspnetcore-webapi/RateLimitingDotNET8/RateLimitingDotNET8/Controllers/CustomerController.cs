using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Diagnostics;

namespace RateLimitingDotNET8.Controllers;

[EnableRateLimiting("fixed")]
public class CustomerController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [EnableRateLimiting("sliding")]
    public ActionResult Details()
    {
        return View();
    }

    [DisableRateLimiting]
    public ActionResult SpecialOffer()
    {
        return View();
    }
}
