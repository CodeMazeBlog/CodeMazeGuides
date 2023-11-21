using Azure.Messaging.ServiceBus;

namespace MessageService;

public class MessageService : IMessageService
{
    Action<string>? messageHandlerCallback;
    private static readonly string connectionString = "{service bus connection string}";

    public async Task SendMessageAsync(string queueOrTopicName, string message)
    {
        var client = CreateClient();

        var sender = client.CreateSender(queueOrTopicName);
        if (sender is null)
        {
            return;
        }

        try
        {
            var serviceBusMessage = new ServiceBusMessage(message);
            await sender.SendMessageAsync(serviceBusMessage);
        }
        finally
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }
    }

    public async Task ReceiveMessagesFromQueueAsync(
        string queueName, Action<string> callback, int millisecondsDelay)
    {
        messageHandlerCallback = callback;
        var client = CreateClient();

        if (client is null)
        {
            return;
        }

        var processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

        try
        {
            await ProcessMessages(millisecondsDelay, processor);
        }
        finally
        {
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }
    }

    public async Task ReceiveMessagesWithSubscriptionAsync(
        string topicName, string subscriptionName, Action<string> callback, int millisecondsDelay)
    {
        messageHandlerCallback = callback;
        var client = CreateClient();

        if (client is null)
        {
            return;
        }

        var processor = client.CreateProcessor(
            topicName, subscriptionName, new ServiceBusProcessorOptions());

        try
        {
            await ProcessMessages(millisecondsDelay, processor);
        }
        finally
        {
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }
    }

    private static ServiceBusClient CreateClient()
    {
        var clientOptions = new ServiceBusClientOptions()
        {
            TransportType = ServiceBusTransportType.AmqpWebSockets
        };

        var client = new ServiceBusClient(connectionString, clientOptions);

        return client;
    }

    private async Task ProcessMessages(int millisecondsDelay, ServiceBusProcessor processor)
    {
        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;
        await processor.StartProcessingAsync();
        Task.Delay(millisecondsDelay).Wait();
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

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());

        return Task.CompletedTask;
    }
}