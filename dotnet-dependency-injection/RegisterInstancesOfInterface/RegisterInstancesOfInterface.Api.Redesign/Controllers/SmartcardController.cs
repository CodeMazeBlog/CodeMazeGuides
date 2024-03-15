using Microsoft.AspNetCore.Mvc;
using RegisterInstancesOfInterface.Api.Redesign.Interfaces;

namespace RegisterInstancesOfInterface.Api.Redesign.Controllers;

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
    public string Post([FromBody] string requestId)
    {
        return _processor.Fulfill(requestId);
    }
}