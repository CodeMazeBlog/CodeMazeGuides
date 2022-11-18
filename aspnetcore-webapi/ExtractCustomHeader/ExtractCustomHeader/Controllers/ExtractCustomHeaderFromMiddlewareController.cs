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
            const string HEADER_KEY_NAME = "MiddlewareHeaderKey";
            HttpContext.Items.TryGetValue(HEADER_KEY_NAME, out object? filterHeaderValue);

            return Ok(filterHeaderValue);
        }
    }
}