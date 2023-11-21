namespace EventBroker;

public class Message
{
    public Message(string topic, string data)
    {
        Topic = topic ?? throw new ArgumentNullException(nameof(topic));
        Data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public string Topic { get; set; }
    public string Data { get; set; }

}