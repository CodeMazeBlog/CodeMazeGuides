using ConditionalRequiredAttributeValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConditionalRequiredAttributeValidation.Controllers;

[Route("api/v1/work-items")]
[ApiController]
public class WorkItemsController : ControllerBase
{
    [HttpPost("create")]
    public Task<IActionResult> CreateWorkItem([FromBody] WorkItem workItem)
    {
        if (!ModelState.IsValid)
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }

        return Task.FromResult<IActionResult>(Ok(workItem));
    }
}   