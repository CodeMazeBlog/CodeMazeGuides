using MessageService;

namespace MessageReceiverApp;

public class MessageReceiver(IMessageService messageService)
{
    public async Task ReceiveMessagesAsync()
    {
        await messageService.ReceiveMessagesFromQueueAsync("queue1", MessageHandler, 30000);
    }

    public static void MessageHandler(string message)
    {
        Console.WriteLine($"Received Message: {message}");
    }
}
