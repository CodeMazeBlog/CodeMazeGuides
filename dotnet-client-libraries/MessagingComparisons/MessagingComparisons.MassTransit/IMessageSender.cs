namespace MessagingComparisons.MassTransit;

public interface IMessageSender
{
    Task SendMessageAsync();
}