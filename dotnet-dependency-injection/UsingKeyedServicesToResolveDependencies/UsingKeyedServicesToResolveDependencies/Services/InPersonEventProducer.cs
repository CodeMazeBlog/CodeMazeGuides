using System.Text;
using UsingKeyedServicesToResolveDependencies.Services.Abstractions;

namespace UsingKeyedServicesToResolveDependencies.Services;

public class InPersonEventProducer(
    [FromKeyedServices("in-person")] IEventService eventService)
{
    public string ProduceEvent()
    {
        var sb = new StringBuilder();

        sb.AppendLine(eventService.StartEvent());
        sb.AppendLine("Custom in-person event logic goes here.");
        sb.AppendLine(eventService.EndEvent());

        return sb.ToString();
    }
}
