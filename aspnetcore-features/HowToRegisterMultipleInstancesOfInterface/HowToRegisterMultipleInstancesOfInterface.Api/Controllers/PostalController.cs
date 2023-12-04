using HowToRegisterMultipleInstancesOfInterface.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostalController : ControllerBase
{
    private readonly IFulfillTickets _processor;

    public PostalController(IFulfillTickets processor)
    {
        _processor = processor;
    }

    [HttpPost()]
    public ActionResult Post([FromBody] string requestId)
    {
        return Ok(_processor.Fulfill(requestId));
    }
}