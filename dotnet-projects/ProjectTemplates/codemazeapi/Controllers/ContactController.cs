using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace codemazeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("visit us at https://code-maze.com/contact/");
        }
    }
}
