using MessageService;

namespace MessagePublisherApp2
{
    public class MessagePublisher2
    {
        private readonly IMessageService _messageService;
        private static readonly string topicName = "topic2";

        public MessagePublisher2(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessages()
        {
            await SendMessageAsync();
            await Task.Delay(5000);
            await SendMessageAsync();
            await Task.Delay(5000);
            await SendMessageAsync();
        }

        private async Task SendMessageAsync()
        {
            DateTime currentDateTime = DateTime.Now;
            string message = new($"Message from sender for topic:{topicName} at {currentDateTime}!");
            await _messageService.SendMessageAsync(topicName, message);
            Console.WriteLine($"Message sent to the queue at {currentDateTime}!");
        }
    }
}
