using MessageService;

namespace MessageSubscriberApp1;

public class MessageSubscriber1(IMessageService messageService)
{
    private static readonly string topicName = "topic1";
    private static readonly string subscriptionName = "s1";

    public async Task ReceiveMessagesAsync()
    {
        await messageService.ReceiveMessagesWithSubscriptionAsync(
            topicName, subscriptionName, MessageHandler, 30000);
    }

    public static void MessageHandler(string message)
    {
        Console.WriteLine(
            $"Received Message: {message} with topic:{topicName}-subscription:{subscriptionName}");
    }
}
