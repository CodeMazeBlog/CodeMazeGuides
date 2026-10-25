using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebApiBestPractices.Application.Services;

namespace WebApiBestPractices.Api.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("api/owners")]
public class OwnersV2Controller(IOwnerService ownerService) : ControllerBase
{
    // Version 2 returns a lighter list: names only.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetOwners(CancellationToken cancellationToken)
    {
        var owners = await ownerService.GetAllAsync(cancellationToken);

        return Ok(owners.Select(o => o.Name));
    }
}
