namespace EventBroker;

public static class Program
{
    public static void Main()
    {
        var broker = new Broker();

        var publisher1 = new Publisher(broker);
        var publisher2 = new Publisher(broker);

        var subscriber1 = new Subscriber(broker, "Subscriber1");
        var subscriber2 = new Subscriber(broker, "Subscriber2");
        var subscriber3 = new Subscriber(broker, "Subscriber3");

        subscriber1.Subscribe("topic1");
        subscriber2.Subscribe("topic2");
        subscriber3.Subscribe("topic1");

        publisher1.Publish(new Message("topic1", "Publisher1 publishing a message for topic1"));
        publisher2.Publish(new Message("topic2", "Publisher2 publishing a message for topic2"));
    }
}