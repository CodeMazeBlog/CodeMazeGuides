namespace MessageService;

public interface IMessageService
{
    Task SendMessageAsync(string queueOrTopicName, string message);
    Task ReceiveMessagesFromQueueAsync(string queueName,
        Action<string> callback,
        int millisecondsDelay);
    Task ReceiveMessagesWithSubscriptionAsync(string topicName,
        string subscriptionName,
        Action<string> callback,
        int millisecondsDelay);
}