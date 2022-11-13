using Microsoft.AspNetCore.Mvc;

namespace ExtractCustomHeader.Controllers
{
    [ApiController]
    [Route("api2/headers")]
    public class ExtractCustomHeaderFromMiddlewareController : ControllerBase
    {
        [HttpGet("from-middleware")]
        public IActionResult ExtractFromMiddleware()
        {
            return Ok();
        }
    }
}