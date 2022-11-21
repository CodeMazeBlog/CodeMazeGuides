using ExtractCustomHeader.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ExtractCustomHeader.Controllers
{
    [ApiController]
    [Route("api/headers")]
    public class ExtractCustomHeaderController : ControllerBase
    {
        [HttpGet("from-basic")]
        public IActionResult ExtractFromBasic()
        {
            const string HeaderKeyName = "HeaderKey";
            Request.Headers.TryGetValue(HeaderKeyName, out StringValues headerValue);

            return Ok(headerValue);
        }

        [HttpGet("from-header-attribute")]
        public IActionResult ExtractFromQueryAttribute([FromHeader] HeaderDTO headerDTO)
        {
            return Ok(headerDTO);
        }

        [HttpGet("from-filter")]
        [ExtractCustomHeader]
        public IActionResult ExtractFromFilter()
        {
            const string HeaderKeyName = "FilterHeaderKey";
            HttpContext.Items.TryGetValue(HeaderKeyName, out object? filterHeaderValue);

            return Ok(filterHeaderValue);
        }
    }
}