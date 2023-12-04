using HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Controllers;

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
    public string Post([FromBody] string requestId)
    {
        return _processor.Fulfill(requestId);
    }
}