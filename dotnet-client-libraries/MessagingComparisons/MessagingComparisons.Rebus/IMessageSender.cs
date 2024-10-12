namespace MessagingComparisons.Rebus;

public interface IMessageSender
{
    Task SendMessageAsync();
}