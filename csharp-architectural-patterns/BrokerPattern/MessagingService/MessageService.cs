using Azure.Messaging.ServiceBus;

namespace MessageService;

public class MessageService : IMessageService
{
    private const string ConnectionString = "{service bus connection string}";

    private static readonly ServiceBusClient ServiceBusClient = CreateClient();

    public async Task SendMessageAsync(string queueOrTopicName, string message)
    {
        await using var sender = ServiceBusClient.CreateSender(queueOrTopicName);
        var serviceBusMessage = new ServiceBusMessage(message);
        await sender.SendMessageAsync(serviceBusMessage);
    }

    public async Task ReceiveMessagesFromQueueAsync(
        string queueName, Action<string> callback, int millisecondsDelay)
    {
        await using var processor = ServiceBusClient.CreateProcessor(
            queueName, new ServiceBusProcessorOptions());
        await ProcessMessages(millisecondsDelay, processor, callback);
    }

    public async Task ReceiveMessagesWithSubscriptionAsync(
        string topicName, string subscriptionName, Action<string> callback, int millisecondsDelay)
    {
        await using var processor = ServiceBusClient.CreateProcessor(
            topicName, subscriptionName, new ServiceBusProcessorOptions());
        await ProcessMessages(millisecondsDelay, processor, callback);
    }

    private static ServiceBusClient CreateClient()
    {
        var clientOptions = new ServiceBusClientOptions()
        {
            TransportType = ServiceBusTransportType.AmqpWebSockets
        };

        return new ServiceBusClient(ConnectionString, clientOptions);
    }

    private static async Task ProcessMessages(int millisecondsDelay, ServiceBusProcessor processor, Action<string> callback)
    {
        processor.ProcessMessageAsync += args => MessageHandler(args, callback);
        processor.ProcessErrorAsync += ErrorHandler;

        await processor.StartProcessingAsync();
        await Task.Delay(millisecondsDelay);
        await processor.StopProcessingAsync();
    }

    private static async Task MessageHandler(ProcessMessageEventArgs args, Action<string> callback)
    {
        var body = args.Message.Body.ToString();
        callback(body);

        await args.CompleteMessageAsync(args.Message);
    }

    private static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());

        return Task.CompletedTask;
    }
}