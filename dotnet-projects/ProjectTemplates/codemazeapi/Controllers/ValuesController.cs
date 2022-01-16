using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace codemazeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("Hi from {DOMAIN} Web API Template");
        }

#if (EnableContactPage)
        [Route("about")]
        public IActionResult About()
        {
            return Ok("visit us at https://code-maze.com/about/");
        }
#endif
    }
}
