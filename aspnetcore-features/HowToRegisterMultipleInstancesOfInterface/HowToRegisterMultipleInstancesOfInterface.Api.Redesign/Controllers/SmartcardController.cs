using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartcardController : ControllerBase
{
    private readonly IFulfillTickets _processor;

    public SmartcardController(IFulfillSmartcardTickets processor)
    {
        _processor = processor;
    }

    [HttpPost()]
    public ActionResult<string> Post([FromBody] string requestId)
    {
        return Ok(_processor.Fulfill(requestId));
    }
}