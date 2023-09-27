using Microsoft.AspNetCore.Mvc;
using UsingKeyedServicesToResolveDependencies.Services;

namespace UsingKeyedServicesToResolveDependencies.Controllers;

[ApiController]
[Route("[controller]")]
public class InPersonEventController : ControllerBase
{
    private readonly InPersonEventOrchestrator _eventOrchestrator;

    public InPersonEventController(InPersonEventOrchestrator eventOrchestrator)
    {
        _eventOrchestrator = eventOrchestrator;
    }

    [HttpGet("EndEvent")]
    public string EndEvent()
        => _eventOrchestrator.EndEvent();

    [HttpGet("StartEvent")]
    public string StartEvent()
        => _eventOrchestrator.StartEvent();
}
