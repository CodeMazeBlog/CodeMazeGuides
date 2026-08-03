using UsingKeyedServicesToResolveDependencies.Services.Abstractions;

namespace UsingKeyedServicesToResolveDependencies.Services;

public class InPersonEventService : IEventService
{
    public string EndEvent()
        => "Ending the in-person event. You can turn on your phones.";

    public string StartEvent()
        => "Starting the in-person event. Please turn off your phones.";
}
