using Microsoft.AspNetCore.Mvc;

namespace CustomHeadersInASPNETCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/custom-headers")]
    public class CustomHeadersController : Controller
    {
        [HttpGet("individual")] 
        public IActionResult CustomHeaderPerResponse() 
        {
            // will be added via middleware - so remove before adding for individual response
            HttpContext.Response.Headers.Remove("x-my-custom-header");

            HttpContext.Response.Headers.Add("x-my-custom-header", "individual response"); 
            return Ok(); 
        }

        [HttpGet("attribute")]
        [CustomHeader]
        public IActionResult CustomHeaderResponseFromAttribute()
        {
            // will be added via middleware - so remove before adding for individual response
            HttpContext.Response.Headers.Remove("x-my-custom-header");

            return Ok();
        }

        [HttpGet("middleware")]
        public IActionResult CustomHeaderResponseFromMiddleware()
        {
            return Ok();
        }
    }
}
