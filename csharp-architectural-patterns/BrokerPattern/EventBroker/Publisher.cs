using EventBroker.Interfaces;

namespace EventBroker;

public class Publisher(IBroker broker)
{
    public void Publish(Message message)
    {
        broker.Publish(message);
    }
}
