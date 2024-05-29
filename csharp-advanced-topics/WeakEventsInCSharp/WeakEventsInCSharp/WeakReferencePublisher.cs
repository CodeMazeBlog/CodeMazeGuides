namespace WeakEventsInCSharp;

public class WeakReferencePublisher
{
    public WeakEvent<EventArgs> Event { get; } = new WeakEvent<EventArgs>();

    public void RaiseEvent()
    {
        Event.RaiseEvent(this, EventArgs.Empty);
    }
}
