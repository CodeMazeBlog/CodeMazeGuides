using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("0.9", Deprecated = true)]
    [ApiVersion("1.0")]
    public class StringListController : ControllerBase
    {
        [HttpGet()]        
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("B"));
        }
    }
}