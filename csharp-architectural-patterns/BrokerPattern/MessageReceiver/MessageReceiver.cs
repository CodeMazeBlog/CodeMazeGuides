using MessageService;

namespace MessageReceiverApp
{
    public class MessageReceiver
    {
        private readonly IMessageService _messageService;

        public MessageReceiver(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task ReceiveMessagesAsync()
        {
            await _messageService.ReceiveMessagesFromQueueAsync("queue1", MessageHandler, 30000);
        }

        public static void MessageHandler(string message)
        {
            Console.WriteLine($"Received Message: {message}");
        }
    }
}
