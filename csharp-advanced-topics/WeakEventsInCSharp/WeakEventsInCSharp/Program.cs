using WeakEventsInCSharp;

//Event Handling - Strong Reference
var publisher = new Publisher();
var subscriber = new Subscriber();
publisher.Event += subscriber.HandleEvent;
publisher.RaiseEvent();
subscriber = null;
GC.Collect();
publisher.RaiseEvent();

//Event Handling - Weak Event
var weakEventPublisher = new WeakReferencePublisher();
var weakEventSubscriber = new WeakReferenceSubscriber();
weakEventSubscriber.Subscribe(weakEventPublisher);
weakEventPublisher.RaiseEvent();
weakEventSubscriber = null;
GC.Collect();
weakEventPublisher.RaiseEvent();
