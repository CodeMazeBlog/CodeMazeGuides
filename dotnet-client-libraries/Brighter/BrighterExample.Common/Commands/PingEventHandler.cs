namespace BrighterExample.Common.Commands;

public class PingEventHandler : RequestHandler<PingEvent>
{
    public override PingEvent Handle(PingEvent pingEvent)
    {
        Console.WriteLine($"[CONSUMER] >> {pingEvent.Id} - {pingEvent.Content}");

        return base.Handle(pingEvent);
    }
}
