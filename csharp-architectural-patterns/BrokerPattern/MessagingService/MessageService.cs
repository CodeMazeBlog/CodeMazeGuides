using Azure.Messaging.ServiceBus;

namespace MessageService;

public class MessageService : IMessageService
{
    Action<string>? messageHandlerCallback;
    private static readonly string connectionString = "{service bus connection string}";

    static ServiceBusClient ServiceBusClient => CreateClient();

    public async Task SendMessageAsync(string queueOrTopicName, string message)
    {
        await using var sender = ServiceBusClient.CreateSender(queueOrTopicName);
        var serviceBusMessage = new ServiceBusMessage(message);
        await sender.SendMessageAsync(serviceBusMessage);
    }

    public async Task ReceiveMessagesFromQueueAsync(
        string queueName, Action<string> callback, int millisecondsDelay)
    {
        messageHandlerCallback = callback;
        await using var processor = ServiceBusClient.CreateProcessor(
            queueName, new ServiceBusProcessorOptions());
        await ProcessMessages(millisecondsDelay, processor);
    }

    public async Task ReceiveMessagesWithSubscriptionAsync(
        string topicName, string subscriptionName, Action<string> callback, int millisecondsDelay)
    {
        messageHandlerCallback = callback;
        await using var processor = ServiceBusClient.CreateProcessor(
            topicName, subscriptionName, new ServiceBusProcessorOptions());
        await ProcessMessages(millisecondsDelay, processor);
    }

    private static ServiceBusClient CreateClient()
    {
        var clientOptions = new ServiceBusClientOptions()
        {
            TransportType = ServiceBusTransportType.AmqpWebSockets
        };

        return new ServiceBusClient(connectionString, clientOptions);
    }

    private async Task ProcessMessages(int millisecondsDelay, ServiceBusProcessor processor)
    {
        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;

        await processor.StartProcessingAsync();
        await Task.Delay(millisecondsDelay);
        await processor.StopProcessingAsync();
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        if (messageHandlerCallback is null)
        {
            return;
        }

        var body = args.Message.Body.ToString();
        messageHandlerCallback(body);

        await args.CompleteMessageAsync(args.Message);
    }

    private static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());

        return Task.CompletedTask;
    }
}