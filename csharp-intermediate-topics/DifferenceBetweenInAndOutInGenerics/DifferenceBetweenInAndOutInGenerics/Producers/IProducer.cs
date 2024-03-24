namespace DifferenceBetweenInAndOutInGenerics.Producers;

using Messages;

public interface IProducer<out TMessage> where TMessage : BaseMessage, new()
{
    TMessage Produce();
}