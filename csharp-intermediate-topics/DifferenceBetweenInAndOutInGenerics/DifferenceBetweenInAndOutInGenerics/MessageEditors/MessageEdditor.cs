namespace DifferenceBetweenInAndOutInGenerics.MessageEditor;

using Messages;

public class MessageEdditor<TMessage> : IMessageEdditor<TMessage> where TMessage : BaseMessage, new()
{
    public void EditOriginalMessage(TMessage message)
    {
        // edit message
    }

    public TMessage EditAndCopyOriginalMessage(TMessage message)
    {
        var newMessage = new TMessage();

        // copy from old to new and edit

        return newMessage;
    }
}