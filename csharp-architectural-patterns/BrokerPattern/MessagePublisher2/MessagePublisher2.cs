using MessageService;

namespace MessagePublisherApp2;

public class MessagePublisher2(IMessageService messageService)
{
    private const string TopicName = "topic2";

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
