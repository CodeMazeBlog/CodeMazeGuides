namespace MessagingComparisons.Domain;

public class MessageSender(IMessageBusStrategy messageBusStrategy, string providerName)
    : IMessageSender
{
    public async Task SendMessageAsync()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = $"Message send using {providerName}"
        };

        await messageBusStrategy.SendMessageAsync(message);
    }
}