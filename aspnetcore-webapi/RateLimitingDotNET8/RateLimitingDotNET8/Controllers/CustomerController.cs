using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingDotNET8.Controllers;

//[EnableRateLimiting(Policies.Fixed)]
[ApiController]
[Route("customer")]
public class CustomerController : ControllerBase
{
    [HttpGet("Index")]
    public ActionResult Index()
    {
        return Ok();
    }

    [HttpGet("Details")]
    [EnableRateLimiting(Policies.Sliding)]
    public ActionResult Details()
    {
        return Ok();
    }

    [HttpGet("GetById")]
    [EnableRateLimiting(Policies.Token)]
    public ActionResult GetById()
    {
        return Ok();
    }

    [HttpGet("Get")]
    [EnableRateLimiting(Policies.Concurrency)]
    public ActionResult Get()
    {
        return Ok();
    }

    [HttpGet("SpecialOffer")]
    [DisableRateLimiting]
    public ActionResult SpecialOffer()
    {
        return Ok();
    }
}
