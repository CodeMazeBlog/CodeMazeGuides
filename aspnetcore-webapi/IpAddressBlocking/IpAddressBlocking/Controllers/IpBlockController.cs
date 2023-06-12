using Microsoft.AspNetCore.Mvc;

namespace IpAddressBlocking.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IpBlockController : ControllerBase
{
    [HttpGet("unblocked")]
    public string Unblocked()
    {
        return "Unblocked access";
    }

    [ServiceFilter(typeof(IpBlockActionFilter))]
    [HttpGet("blocked")]
    public string Blocked()
    {
        return "Blocked access";
    }
}
