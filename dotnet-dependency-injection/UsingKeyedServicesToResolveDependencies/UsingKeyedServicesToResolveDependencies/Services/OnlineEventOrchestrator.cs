using UsingKeyedServicesToResolveDependencies.Services.Abstractions;

namespace UsingKeyedServicesToResolveDependencies.Services;

public class OnlineEventOrchestrator
{
    private readonly IEventService _eventService;

    public OnlineEventOrchestrator([FromKeyedServices("online")] IEventService eventService)
    {
        _eventService = eventService;
    }

    public string EndEvent() => _eventService.EndEvent();

    public string StartEvent() => _eventService.StartEvent();
}
