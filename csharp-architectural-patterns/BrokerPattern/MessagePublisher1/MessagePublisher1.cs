using MessageService;

namespace MessagePublisherApp1;

public class MessagePublisher1(IMessageService messageService)
{
    private const string TopicName = "topic1";

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
        var message = $"Message from sender for topic:{TopicName} at {currentDateTime}!";
        await messageService.SendMessageAsync(TopicName, message);
        Console.WriteLine($"Message sent for topic:{TopicName} at {currentDateTime}!");
    }
}
