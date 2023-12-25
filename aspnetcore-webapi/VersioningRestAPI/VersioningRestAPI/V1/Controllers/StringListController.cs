using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace VersioningRestAPI.V1.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0", Deprecated = true)]
public class StringListController : ControllerBase
{
    [HttpGet()]        
    public IEnumerable<string> Get()
    {
        return Data.Summaries.Where(x => x.StartsWith("B"));
    }
}