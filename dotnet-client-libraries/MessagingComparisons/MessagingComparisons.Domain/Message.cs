using NServiceBus;

namespace MessagingComparisons.Domain;

public class Message : IMessage
{
    public string MessageId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}