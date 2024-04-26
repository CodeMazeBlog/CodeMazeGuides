namespace DifferenceBetweenInAndOutInGenerics.MessageEditor;

using Messages;

public class MessageEditor<TMessage> : IMessageEditor<TMessage> where TMessage : BaseMessage, new()
{
    public TMessage EditAndCopyOriginalMessage(TMessage message)
    {
        var newMessage = new TMessage();

        // copy from old to new and edit

        return newMessage;
    }
}