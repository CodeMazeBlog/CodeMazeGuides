namespace DifferenceBetweenInAndOutInGenerics.MessageEditor;

using Messages;

public interface IMessageEditor<TMessage> where TMessage : BaseMessage, new()
{
    TMessage EditAndCopyOriginalMessage(TMessage message);
}