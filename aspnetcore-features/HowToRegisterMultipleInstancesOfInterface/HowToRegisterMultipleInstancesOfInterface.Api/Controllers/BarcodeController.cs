using HowToRegisterMultipleInstancesOfInterface.Interfaces;
using HowToRegisterMultipleInstancesOfInterface.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BarcodeController : ControllerBase
{
    private readonly IFulfillTickets _processor;
    private readonly ILogger<BarcodeController> _logger;

    public BarcodeController(IFulfillTickets processor, ILogger<BarcodeController> logger)
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