using MessageService;

namespace MessageSenderApp;

public class MessageSender(IMessageService messageService)
{
    public async Task SendMessagesAsync()
    {
        await SendMessageAsync();
        await Task.Delay(5);
        await SendMessageAsync();
        await Task.Delay(5);
        await SendMessageAsync();
    }

    private async Task SendMessageAsync()
    {
        var currentDateTime = DateTime.Now;
        var message = $"Message from sender at {currentDateTime}!";
        await messageService.SendMessageAsync("queue1", message);
        Console.WriteLine($"Message sent to the queue at {currentDateTime}!");
    }
}
