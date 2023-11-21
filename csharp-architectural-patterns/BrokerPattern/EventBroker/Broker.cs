using EventBroker.Interfaces;

namespace EventBroker;

public class Broker : IBroker
{
    private readonly Dictionary<string, List<Action<Message>>> _subsciptions = new();

    public void Publish(Message message)
    {
        if (_subsciptions.ContainsKey(message.Topic))
        {
            foreach (var callback in _subsciptions[message.Topic])
            {
                callback(message);
            }
        }
    }

    public void Subscribe(string topic, Action<Message> callback)
    {
        if (!_subsciptions.ContainsKey(topic))
        {
            _subsciptions.Add(topic, new List<Action<Message>>());
        }

        _subsciptions[topic].Add(callback);
    }
}
