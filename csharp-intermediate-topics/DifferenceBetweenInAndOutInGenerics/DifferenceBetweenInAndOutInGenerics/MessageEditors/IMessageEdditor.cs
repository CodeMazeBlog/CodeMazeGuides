namespace DifferenceBetweenInAndOutInGenerics.MessageEditor;

using Messages;

public interface IMessageEdditor<TMessage> where TMessage : BaseMessage, new()
{
    TMessage EditAndCopyOriginalMessage(TMessage message);
}