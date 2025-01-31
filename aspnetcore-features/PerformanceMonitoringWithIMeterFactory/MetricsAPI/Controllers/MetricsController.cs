using MetricsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MetricsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetricsController(IMetricsService metricsService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var random = Random.Shared;

        metricsService.RecordUserClick();

        for (int i = 0; i < 100; i++)
        {
            metricsService.RecordResponseTime(random.NextDouble());
        }

        metricsService.RecordRequest();

        metricsService.RecordMemoryConsumption(GC.GetAllocatedBytesForCurrentThread() / (1024 * 1024));

        metricsService.RecordUserClickDetailed("US", "checkout");

        metricsService.RecordResourceUsage(
            Utilities.GetCpuUsagePercentage(),
            GC.GetTotalAllocatedBytes() / (1024 * 1024),
            Process.GetCurrentProcess().Threads.Count);

        return Ok();
    }
}
