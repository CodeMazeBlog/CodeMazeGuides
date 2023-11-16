using HowToRegisterMultipleInstancesOfInterface.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HowToRegisterMultipleInstancesOfInterface.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FulfillmentController : ControllerBase
{
    private readonly ILogger<FulfillmentController> _logger;

    public FulfillmentController(ILogger<FulfillmentController> logger)
    {
        _logger = logger;
    }

    [HttpPost()]
    public ActionResult Post([FromBody] FulfilmentRequest request)
    {
        return Ok();
    }
}