using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    public class StringListController : Controller
    {
        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("S"));
        }
    }
}
