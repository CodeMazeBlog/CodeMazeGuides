using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V3.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/StringList")]
    [ApiVersion("3.0")]
    public class StringListController : Controller
    {
        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("C"));
        }
    }
}
