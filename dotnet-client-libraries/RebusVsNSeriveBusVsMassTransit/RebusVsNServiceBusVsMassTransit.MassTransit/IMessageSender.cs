namespace RebusVsNServiceBusVsMassTransit.MassTransit;

public interface IMessageSender
{
    Task SendMessageAsync();
}