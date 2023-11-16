using MessageService;

namespace MessageSenderApp
{
    public class MessageSender
    {
        private readonly IMessageService _messageService;

        public MessageSender(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessagesAsync()
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
            string message = new($"Message from sender at {currentDateTime}!");
            await _messageService.SendMessageAsync("queue1", message);
            Console.WriteLine($"Message sent to the queue at {currentDateTime}!");
        }
    }
}
