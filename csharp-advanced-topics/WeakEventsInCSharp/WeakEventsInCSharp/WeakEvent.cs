namespace WeakEventsInCSharp;

public class WeakEvent<TEventArgs> where TEventArgs : EventArgs
{
    private readonly List<WeakReference<EventHandler<TEventArgs>>> _eventHandlers = [];

    public bool HandlerInvoked { get; private set; }

    public void AddEventHandler(EventHandler<TEventArgs> handler)
    {
        if (handler is null) return;

        _eventHandlers.Add(new WeakReference<EventHandler<TEventArgs>>(handler));
    }

    public void RemoveEventHandler(EventHandler<TEventArgs> handler)
    {
        var eventHandler = _eventHandlers.FirstOrDefault(wr =>
        {
            wr.TryGetTarget(out var target);

            return target == handler;
        });

        if (eventHandler is not null)
        {
            _eventHandlers.Remove(eventHandler);
        }
    }

    public void RaiseEvent(object sender, TEventArgs e)
    {
        HandlerInvoked = false;

        foreach (var eventHandler in _eventHandlers.ToArray())
        {
            if (eventHandler.TryGetTarget(out var handler))
            {
                handler(sender, e);
                HandlerInvoked = true;
            }
        }
    }
}