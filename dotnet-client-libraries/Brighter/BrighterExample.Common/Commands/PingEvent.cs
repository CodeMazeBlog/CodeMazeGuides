namespace BrighterExample.Common;

public class PingEvent() : Event(Guid.NewGuid())
{
    public string Content { get; set; } = $"Ping at {DateTime.Now}";
}
