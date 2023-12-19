using EventBroker.Interfaces;

namespace EventBroker;

public class Broker : IBroker
{
    private readonly Dictionary<string, List<Action<Message>>> _subsrciptions = new();

    public void Publish(Message message)
    {
        if (_subsrciptions.TryGetValue(message.Topic, out List<Action<Message>>? callbacks))
        {
            foreach (var callback in callbacks)
            {
                callback(message);
            }
        }
    }

    public void Subscribe(string topic, Action<Message> callback)
    {
        if (!_subsrciptions.TryGetValue(topic, out List<Action<Message>>? value))
        {
            value = [];
            _subsrciptions.Add(topic, value);
        }

        value.Add(callback);
    }
}
