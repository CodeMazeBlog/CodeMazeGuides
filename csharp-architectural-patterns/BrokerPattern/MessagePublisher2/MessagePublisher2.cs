using MessageService;

namespace MessagePublisherApp2;

public class MessagePublisher2(IMessageService messageService)
{
    private static readonly string topicName = "topic2";

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
        var currentDateTime = DateTime.Now;
        var message = $"Message from sender for topic:{topicName} at {currentDateTime}!";
        await messageService.SendMessageAsync(topicName, message);
        Console.WriteLine($"Message sent for topic:{topicName} at {currentDateTime}!");
    }
}
