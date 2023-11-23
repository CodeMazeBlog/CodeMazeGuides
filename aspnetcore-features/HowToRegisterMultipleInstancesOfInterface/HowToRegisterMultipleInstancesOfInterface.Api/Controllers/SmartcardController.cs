using HowToRegisterMultipleInstancesOfInterface.Interfaces;
using HowToRegisterMultipleInstancesOfInterface.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SmartcardController : ControllerBase
{
    private readonly IFulfillTickets _processor;
    private readonly ILogger<SmartcardController> _logger;

    public SmartcardController(IFulfillTickets processor, ILogger<SmartcardController> logger)
    {
        _processor = processor;
        _logger = logger;
    }

    [HttpPost()]
    public ActionResult Post([FromBody] FulfilmentRequest request)
    {
        return Ok(_processor.Fulfill(request.RequestId));
    }
}