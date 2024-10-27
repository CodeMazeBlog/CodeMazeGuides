namespace MessagingComparisons.Domain.Interfaces;

public interface IMessageSender
{
    Task SendMessageAsync();
}