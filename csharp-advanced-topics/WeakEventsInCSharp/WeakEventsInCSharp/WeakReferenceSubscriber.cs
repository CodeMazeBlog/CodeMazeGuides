namespace WeakEventsInCSharp;

public class WeakReferenceSubscriber
{
    public void Subscribe(WeakReferencePublisher publisher)
    {
        publisher.Event.AddEventHandler(HandleEvent);
    }

    public void HandleEvent(object? sender, EventArgs e)
    {
        Console.WriteLine("Weak Event received.");
    }
}
