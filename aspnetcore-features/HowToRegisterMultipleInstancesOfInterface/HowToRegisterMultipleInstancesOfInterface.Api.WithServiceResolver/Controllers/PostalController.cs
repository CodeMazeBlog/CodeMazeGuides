using HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.WithServiceResolver.Controllers;

[ApiController]
[Route("[controller]")]
public class PostalController : ControllerBase
{
    private readonly IFulfillTickets _processor;

    public PostalController(FulfillmentProcessorResolver serviceResolver)
    {
        _processor = serviceResolver("postal");
    }

    [HttpPost()]
    public string Post([FromBody] string requestId)
    {
        return _processor.Fulfill(requestId);
    }
}