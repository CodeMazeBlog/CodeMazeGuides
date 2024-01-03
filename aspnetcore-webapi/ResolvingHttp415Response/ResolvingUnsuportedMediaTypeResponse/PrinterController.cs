using Microsoft.AspNetCore.Mvc;

namespace ResolvingUnsuportedMediaTypeResponse;

[Route("api/[Controller]/[Action]")]
public class PrinterController : Controller
{
        [HttpPost]
        public IActionResult Print([FromBody] string data)
        {
            return Ok($"Recievd: {data}");
        }
        // Web API approach using [FromBody]
        
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        public IActionResult PrintFromBody([FromBody] string data)
        {
            return Ok($"Received (FromBody): {data}");
        }

        // MVC approach using [FromForm]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded", "application/xml")]
        [Produces("application/json", "text/plain")]
        public IActionResult PrintFromForm([FromForm] string data)
        {
            return Ok($"Received (FromForm): {data}");
        }

        [HttpPost]
        [ProducesResponseType(415, Type = typeof(string))]
        public IActionResult PrintFromBodyManualCheck([FromBody] string data)
        {
            if (!Request.ContentType.StartsWith("application/json"))
            {
                return UnsupportedMediaType(Request.ContentType);
            }
            return Ok($"Received (FromBody): {data}");
        }

        private IActionResult UnsupportedMediaType(string type)
        {
            Response.StatusCode = 415;
            Response.ContentType = "text/plain";
            return Content($"Unsupported Media Type. Received: {type} Expected: application/json");
        }
}
