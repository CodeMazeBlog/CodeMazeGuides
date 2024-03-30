namespace DifferenceBetweenInAndOutInGenerics.Consumers;

using Messages;

public class Consumer<TMessage> : IConsumer<TMessage> where TMessage : BaseMessage, new()
{
    public void Consume(TMessage message) => Console.WriteLine($"Consumed {message.GetType().Name}");
}