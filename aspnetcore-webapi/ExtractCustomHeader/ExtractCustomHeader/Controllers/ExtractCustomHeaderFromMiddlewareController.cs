using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

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
            Request.Headers.TryGetValue(HEADER_KEY_NAME, out StringValues headerValue);

            return Ok(filterHeaderValue);
        }
    }
}