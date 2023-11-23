using HowToRegisterMultipleInstancesOfInterface.Interfaces;
using HowToRegisterMultipleInstancesOfInterface.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostalController : ControllerBase
{
    private readonly IFulfillTickets _processor;
    private readonly ILogger<PostalController> _logger;

    public PostalController(IFulfillTickets processor, ILogger<PostalController> logger)
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