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
            const string HeaderKeyName = "MiddlewareHeaderKey";
            HttpContext.Items.TryGetValue(HeaderKeyName, out object? filterHeaderValue);

            return Ok(filterHeaderValue);
        }
    }
}