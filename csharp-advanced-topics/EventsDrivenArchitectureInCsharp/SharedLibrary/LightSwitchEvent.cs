namespace Events;

public class LightSwitchEvent
{
    public Guid CorrelationId { get; set; }
    public LightState State { get; set; }
}