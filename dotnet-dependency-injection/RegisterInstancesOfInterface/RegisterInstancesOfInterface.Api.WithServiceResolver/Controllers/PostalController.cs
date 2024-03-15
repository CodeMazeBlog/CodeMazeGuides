using Microsoft.AspNetCore.Mvc;
using RegisterInstancesOfInterface.Api.WithServiceResolver.Shared;
using RegisterInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Controllers;

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