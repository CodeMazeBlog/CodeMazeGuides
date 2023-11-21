using EventBroker.Interfaces;

namespace EventBroker;

public class Publisher
{
    private readonly IBroker _broker;

    public Publisher(IBroker broker)
    {
        _broker = broker;
    }

    public void Publish(Message message)
    {
        _broker.Publish(message);
    }
}
