using NServiceBus;

namespace RebusVsNServiceBusVsMassTransit.Domain;

public class Message : IMessage
{
    public string MessageId { get; set; }
    public string Content { get; set; }
}