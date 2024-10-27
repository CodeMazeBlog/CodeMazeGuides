namespace MessagingComparisons.Domain.Interfaces;

public interface IMessageBusStrategy
{
    Task SendMessageAsync(Message message);
}