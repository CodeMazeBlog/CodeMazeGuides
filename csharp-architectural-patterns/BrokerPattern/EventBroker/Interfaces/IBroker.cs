namespace EventBroker.Interfaces;

public interface IBroker
{
    void Publish(Message message);
    void Subscribe(string topic, Action<Message> callback);
}
