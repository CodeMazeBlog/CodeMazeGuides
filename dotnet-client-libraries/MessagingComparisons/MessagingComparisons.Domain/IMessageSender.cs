namespace MessagingComparisons.Domain;

public interface IMessageSender
{
    Task SendMessageAsync();
}