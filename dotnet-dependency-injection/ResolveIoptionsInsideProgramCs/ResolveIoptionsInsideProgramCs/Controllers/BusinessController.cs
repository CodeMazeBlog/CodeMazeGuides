namespace ResolveIoptionsInsideProgramCs.Controllers;

using Microsoft.AspNetCore.Mvc;
using ResolveIoptionsInsideProgramCs.Services;
using System.Net.Mime;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class BusinessController : ControllerBase
{
    private readonly IBusinessService _businessService;

    public BusinessController(IBusinessService businessService)
    {
        _businessService = businessService;
    }

    [HttpGet("api/business/get-settings")]
    public IActionResult GetSettings()
    {
        var settings = _businessService.GetMySettings();

        return Ok(settings);
    }
}
