using HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartcardController : ControllerBase
{
    private readonly IFulfillTickets _processor;

    public SmartcardController(FulfillmentProcessorResolver serviceResolver)
    {
        _processor = serviceResolver("smartcard");
    }

    [HttpPost()]
    public ActionResult<string> Post([FromBody] string requestId)
    {
        return Ok(_processor.Fulfill(requestId));
    }
}