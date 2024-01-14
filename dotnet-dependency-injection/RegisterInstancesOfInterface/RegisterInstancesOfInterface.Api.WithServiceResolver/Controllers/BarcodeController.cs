using Microsoft.AspNetCore.Mvc;
using RegisterInstancesOfInterface.Api.WithServiceResolver.Shared;
using RegisterInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Controllers;

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