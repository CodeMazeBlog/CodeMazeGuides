using NServiceBus;

namespace MessagingComparisons.Domain;

public class Message : IMessage
{
    public string MessageId { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
}