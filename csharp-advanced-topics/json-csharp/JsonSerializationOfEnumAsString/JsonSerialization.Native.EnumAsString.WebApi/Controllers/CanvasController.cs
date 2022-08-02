using JsonSerialization.EnumAsString.Models;
using Microsoft.AspNetCore.Mvc;

namespace JsonSerialization.Native.EnumAsString.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CanvasController : ControllerBase
{
    [HttpGet("poster")]
    public Canvas GetPoster() => Canvas.Poster;

    [HttpGet("schedule")]
    public object GetSchedule() => new { Description = "Exhibition", Day = DayOfWeek.Monday };
}