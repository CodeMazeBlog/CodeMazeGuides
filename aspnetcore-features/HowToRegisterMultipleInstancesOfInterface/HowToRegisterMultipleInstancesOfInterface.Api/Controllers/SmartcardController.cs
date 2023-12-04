using HowToRegisterMultipleInstancesOfInterface.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartcardController : ControllerBase
{
    private readonly IFulfillTickets _processor;

    public SmartcardController(IFulfillTickets processor)
    {
        _processor = processor;
    }

    [HttpPost()]
    public ActionResult Post([FromBody] string requestId)
    {
        return Ok(_processor.Fulfill(requestId));
    }
}