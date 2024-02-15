namespace FixCorsProtocolErrorWithAnyOriginAndAllowCredentials.Api.Controllers;

[ApiController]
[Route("api/dummy")]
public class DummyController : ControllerBase
{
    [HttpGet]
    [Route("bad")]
    [EnableCors("BadPolicy")]
    public IActionResult GetBad()
    {
        var message = "Sorry, this won't work!";

        return Ok(message);
    }

    [HttpGet]
    [Route("good")]
    [EnableCors("GoodPolicy")]
    public IActionResult GetGood()
    {
        var message = "This is working fine!";

        return Ok(message);
    }

    [HttpGet]
    [Route("best")]
    [EnableCors("BestPolicy")]
    public IActionResult GetBest()
    {
        var message = "This is the best!";

        return Ok(message);
    }
}