using MessageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageSubscriberApp2;

public static class Program
{
    public static async Task Main()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<IMessageService, MessageService.MessageService>();
        builder.Services.AddSingleton<MessageSubscriber2>();

        var serviceProvider = builder.Services.BuildServiceProvider();

        var myService = serviceProvider.GetService<MessageSubscriber2>();
        await myService.ReceiveMessagesAsync();
    }
}