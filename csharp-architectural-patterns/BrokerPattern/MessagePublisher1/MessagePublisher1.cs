﻿using MessageService;

namespace MessagePublisherApp1;

public class MessagePublisher1
{
    private readonly IMessageService _messageService;
    private static readonly string topicName = "topic1";

    public MessagePublisher1(IMessageService messageService)
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
        var currentDateTime = DateTime.Now;
        var message = $"Message from sender for topic:{topicName} at {currentDateTime}!";
        await _messageService.SendMessageAsync(topicName, message);
        Console.WriteLine($"Message sent to the queue at {currentDateTime}!");
    }
}