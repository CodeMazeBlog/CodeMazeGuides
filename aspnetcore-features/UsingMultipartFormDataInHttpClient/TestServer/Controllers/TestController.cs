using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace TestServer1.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("upload-form")]
        public IActionResult Post()
        {
            if (Request.Form.ContainsKey("first_name") &&
                Request.Form.ContainsKey("last_name"))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("upload-image")]
        public IActionResult PostFile()
        {
            var files = Request.Form.Files;
            if (files.Count == 1 &&
                files.First().FileName == "john_doe.jpg" &&
                files.First().ContentType == MediaTypeNames.Image.Jpeg)
            {
                return Ok();
            }
            
            return BadRequest();
        }
    }
}