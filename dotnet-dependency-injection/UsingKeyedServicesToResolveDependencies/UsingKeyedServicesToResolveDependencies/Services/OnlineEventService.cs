using UsingKeyedServicesToResolveDependencies.Services.Abstractions;

namespace UsingKeyedServicesToResolveDependencies.Services;

public class OnlineEventService : IEventService
{
    public string EndEvent()
        => "Ending the in-person event. You can turn on your microphones.";

    public string StartEvent()
        => "Starting the online event. Please turn off your microphones.";
}
