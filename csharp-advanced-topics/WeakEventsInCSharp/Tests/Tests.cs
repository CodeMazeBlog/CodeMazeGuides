using WeakEventsInCSharp;

namespace Tests;

public class Tests
{
    private bool _eventHandled;

    [Fact]
    public void GivenStrongEventWhenGCCollectedThenEventRaised()
    {
        var publisher = new Publisher();
        var subscriber = new Subscriber();

        publisher.Event += EventHandlerMethod;
        publisher.RaiseEvent();

        Assert.True(_eventHandled);

        subscriber = null;
        GC.Collect();
        publisher.RaiseEvent();

        Assert.True(_eventHandled);
    }

    [Fact]
    public void GivenWeakEventWhenGCCollectedThenEventNotRaised()
    {
        var weakEventPublisher = new WeakReferencePublisher();
        var weakEventSubscriber = new WeakReferenceSubscriber();
        weakEventSubscriber.Subscribe(weakEventPublisher);
        weakEventPublisher.RaiseEvent();

        Assert.True(weakEventPublisher.Event.HandlerInvoked);

        weakEventSubscriber = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        weakEventPublisher.RaiseEvent();

        Assert.False(weakEventPublisher.Event.HandlerInvoked);
    }

    private void EventHandlerMethod(object? sender, EventArgs e)
    {
        _eventHandled = true;
    }
}