using EventBroker.Interfaces;

namespace EventBroker;

public class Subscriber(IBroker broker, string name)
{
    public void Subscribe(string topic)
    {
        broker.Subscribe(topic, (message) =>
        {
            Console.WriteLine($"{name} received a message: {message.Data}.");
        });
    }
}