using MetricsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MetricsController(IMetricsService metricsService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        Random random = new();

        metricsService.RecordUserClick();

        for (int i = 0; i < 100; i++)
        {
            metricsService.RecordResponseTime(random.NextDouble());
        }

        metricsService.RecordRequest();

        metricsService.RecordMemoryConsumption(random.NextDouble() * 1000);

        metricsService.RecordUserClickDetailed("US", "checkout");

        metricsService.RecordResourceUsage(random.Next(1, 100), random.Next(16, 2048), random.Next(1, 16));

        return Ok();
    }
}
