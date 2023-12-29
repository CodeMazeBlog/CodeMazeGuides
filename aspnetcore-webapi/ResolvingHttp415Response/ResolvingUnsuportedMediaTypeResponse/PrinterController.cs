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
        public IActionResult PrintFromBody([FromBody] string data)
        {
            return Ok($"Received (FromBody): {data}");
        }

        // MVC approach using [FromForm]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult PrintFromForm([FromForm] string data)
        {
            return Ok($"Received (FromForm): {data}");
        }
}
