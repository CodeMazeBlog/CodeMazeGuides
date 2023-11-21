using EventBroker.Interfaces;

namespace EventBroker;

public class Subscriber
{
    private readonly IBroker _broker;
    public string Name { get; set; }

    public Subscriber(IBroker broker, string name)
    {
        _broker = broker ?? throw new ArgumentNullException(nameof(broker));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void Subscribe(string topic)
    {
        _broker.Subscribe(topic, (message) =>
        {
            Console.WriteLine($"{Name} received a message: {message.Data}.");
        });
    }
}
