namespace RebusVsNServiceBusVsMassTransit.Rebus;

public interface IMessageSender
{
    Task SendMessageAsync();
}