namespace BrighterExample.Common;

public class PingEvent() : Event(Guid.NewGuid())
{
    public string Content { get; set; } = $"Ping at {DateTime.Now}";
}

public class PingEventHandler : RequestHandler<PingEvent>
{
    public override PingEvent Handle(PingEvent @event)
    {
        Console.WriteLine("--------------- [CONSUMER] -------------------");
        Console.WriteLine($"EVENT   : {@event.Content}");
        Console.WriteLine($"EVENT-ID: {@event.Id}");
        Console.WriteLine("----------------------------------------------");
        return base.Handle(@event);
    }
}