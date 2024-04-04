namespace DifferenceBetweenInAndOutInGenerics.Producers;

using Messages;

public class Producer<TMessage> : IProducer<TMessage> where TMessage : BaseMessage, new()
{
    public TMessage Produce()
    {
        var message = new TMessage();

        Console.WriteLine($"Produced {message.GetType().Name}");

        return message;
    }
}