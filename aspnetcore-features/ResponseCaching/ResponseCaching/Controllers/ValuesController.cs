using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace response_caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(CacheProfileName = "Cache2Mins")]
        public IActionResult Get()
        {
            return Ok($"Response was generated at {DateTime.Now}");
        }
    }
}
