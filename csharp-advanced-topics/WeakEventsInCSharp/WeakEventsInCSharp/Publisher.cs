namespace WeakEventsInCSharp;

public class Publisher
{
    public event EventHandler? Event;

    public void RaiseEvent()
    {
        Event?.Invoke(this, EventArgs.Empty);
    }
}
