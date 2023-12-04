using HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Redesign.Controllers;

[ApiController]
[Route("[controller]")]
public class BarcodeController : ControllerBase
{
    private readonly IFulfillTickets _processor;
    
    public BarcodeController(IFulfillBarcodeTickets processor)
    {
        _processor = processor;
    }

    [HttpPost()]
    public ActionResult Post([FromBody] string requestId)
    {
        return Ok(_processor.Fulfill(requestId));
    }
}