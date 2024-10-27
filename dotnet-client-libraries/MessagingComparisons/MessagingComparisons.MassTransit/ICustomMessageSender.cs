using MessagingComparisons.Domain;

namespace MessagingComparisons.MassTransit;

public interface ICustomMessageSender
{
    Task SendMessageAsync(Message message, string queueUri);
}