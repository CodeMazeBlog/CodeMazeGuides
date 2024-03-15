using Microsoft.AspNetCore.Mvc;

namespace WebApiReturnXml.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        [Produces("application/xml")]
        public IActionResult GetUser(int id)
        {
            var user = new User { Id = id, Name = "Steve James" };

            return Ok(user);
        }
    }
}
