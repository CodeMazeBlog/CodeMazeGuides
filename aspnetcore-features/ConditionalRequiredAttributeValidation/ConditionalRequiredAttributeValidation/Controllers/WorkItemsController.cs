using ConditionalRequiredAttributeValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConditionalRequiredAttributeValidation.Controllers;

[Route("api/v1/work-items")]
[ApiController]
public class WorkItemsController : ControllerBase
{
    [HttpPost("create")]
    public IActionResult CreateWorkItem([FromBody] WorkItem workItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(workItem);
    }
}   