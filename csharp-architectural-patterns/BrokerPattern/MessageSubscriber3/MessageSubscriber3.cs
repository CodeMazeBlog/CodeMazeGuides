using MessageService;

namespace MessageSubscriberApp3
{
    public class MessageSubscriber3
    {
        private readonly IMessageService _messageService;
        private static readonly string topicName = "topic2";
        private static readonly string subscriptionName = "s1";

        public MessageSubscriber3(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task ReceiveMessagesAsync()
        {
            await _messageService.ReceiveMessagesWithSubscriptionAsync(topicName, subscriptionName, MessageHandler, 30000);
        }

        public static void MessageHandler(string message)
        {
            Console.WriteLine($"Received Message: {message} with topic:{topicName}-subscription:{subscriptionName}");
        }
    }
}
