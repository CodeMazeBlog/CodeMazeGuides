using HowToRegisterMultipleInstancesOfInterface.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BarcodeController : ControllerBase
{
    private readonly IFulfillTickets _processor;
    public BarcodeController(FulfillmentProcessorResolver serviceResolver)
    {
        _processor = serviceResolver("barcode");
    }

    [HttpPost()]
    public ActionResult Post([FromBody] string requestId)
    {
        return Ok(_processor.Fulfill(requestId));
    }
}