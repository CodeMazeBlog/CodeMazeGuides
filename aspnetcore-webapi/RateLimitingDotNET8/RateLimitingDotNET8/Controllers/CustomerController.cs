using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingDotNET8.Controllers;

[EnableRateLimiting(Policies.Fixed)]
public class CustomerController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [EnableRateLimiting(Policies.Sliding)]
    public ActionResult Details()
    {
        return View();
    }

    [EnableRateLimiting(Policies.Token)]
    public ActionResult GetById()
    {
        return View();
    }

    [EnableRateLimiting(Policies.Concurrency)]
    public ActionResult Get()
    {
        return View();
    }

    [DisableRateLimiting]
    public ActionResult SpecialOffer()
    {
        return View();
    }
}
