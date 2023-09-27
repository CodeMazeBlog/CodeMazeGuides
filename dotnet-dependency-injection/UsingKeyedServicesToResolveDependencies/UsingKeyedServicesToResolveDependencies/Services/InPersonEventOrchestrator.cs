using UsingKeyedServicesToResolveDependencies.Services.Abstractions;

namespace UsingKeyedServicesToResolveDependencies.Services;

public class InPersonEventOrchestrator
{
    private readonly IEventService _eventService;

    public InPersonEventOrchestrator([FromKeyedServices("in-person")] IEventService eventService)
    {
        _eventService = eventService;
    }

    public string EndEvent() => _eventService.EndEvent();

    public string StartEvent() => _eventService.StartEvent();
}
