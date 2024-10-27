using NServiceBus;

namespace MessagingComparisons.Domain;

public class MessageWithQueueName : Message
{
    public string QueueName { get; set; } = String.Empty;
}