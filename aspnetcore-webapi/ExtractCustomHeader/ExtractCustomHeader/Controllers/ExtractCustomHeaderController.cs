using ExtractCustomHeader.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ExtractCustomHeader.Controllers
{
    [ApiController]
    [Route("api/headers")]
    public class ExtractCustomHeaderController : ControllerBase
    {
        [HttpGet("from-request")]
        public IActionResult ExtractFromRequest()
        {
            const string HEADER_KEY_NAME = "HeaderKey";
            Request.Headers.TryGetValue(HEADER_KEY_NAME, out StringValues headerValue);

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
            return Ok();
        }
    }
}