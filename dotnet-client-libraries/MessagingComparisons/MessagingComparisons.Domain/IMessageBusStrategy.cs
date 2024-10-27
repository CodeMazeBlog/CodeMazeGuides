namespace MessagingComparisons.Domain;

public interface IMessageBusStrategy
{
    Task SendMessageAsync(Message message);
}