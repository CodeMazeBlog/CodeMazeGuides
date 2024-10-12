namespace MessagingComparisons.NServiceBus;

public interface IMessageSender
{
    Task SendMessageAsync();
}