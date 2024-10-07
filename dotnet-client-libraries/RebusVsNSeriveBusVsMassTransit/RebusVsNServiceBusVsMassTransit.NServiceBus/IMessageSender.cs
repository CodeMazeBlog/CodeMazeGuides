namespace RebusVsNServiceBusVsMassTransit.NServiceBus;

public interface IMessageSender
{
    Task SendMessageAsync();
}