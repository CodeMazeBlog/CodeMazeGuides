using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureFlags.Controllers;
[Route("[controller]")]
[ApiController]
public class FeatureFlagController : ControllerBase
{
    private readonly IFeatureManager _featureManager;

    public FeatureFlagController(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    [HttpGet("BooleanFilter")]
    public async Task<IActionResult> BooleanFilter()
    {
        if (await _featureManager.IsEnabledAsync("BooleanFilter"))
        {
            return Ok("Feature enabled");
        }
        else
        {
            return BadRequest("Feature not enabled");
        }
    }

    [HttpGet("PercentageFilter")]
    public async Task<IActionResult> PercentageFilter()
    {
        if (await _featureManager.IsEnabledAsync("PercentageFilter"))
        {
            return Ok("Feature enabled");
        }
        else
        {
            return BadRequest("Feature not enabled");
        }
    }

    [HttpGet("CustomFilter")]
    public async Task<IActionResult> CustomFilter()
    {
        if (await _featureManager.IsEnabledAsync("CustomFilter"))
        {
            return Ok("Feature enabled");
        }
        else
        {
            return BadRequest("Feature not enabled");
        }
    }

    [HttpGet("TimeWindowFilter")]
    public async Task<IActionResult> TimeWindowFilter()
    {
        if (await _featureManager.IsEnabledAsync("TimeWindowFilter"))
        {
            return Ok("Feature enabled");
        }
        else
        {
            return BadRequest("Feature not enabled");
        }
    }
}
