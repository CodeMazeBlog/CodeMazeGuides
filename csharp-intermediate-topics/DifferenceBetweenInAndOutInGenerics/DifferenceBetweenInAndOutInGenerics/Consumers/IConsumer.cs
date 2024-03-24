namespace DifferenceBetweenInAndOutInGenerics.Consumers;

using Messages;

public interface IConsumer<in TMessage> where TMessage : BaseMessage, new()
{
    void Consume(TMessage message);
}