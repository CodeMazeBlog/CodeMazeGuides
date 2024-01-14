using MessageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessagePublisherApp1;

public static class Program
{
    public static async Task Main()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<IMessageService, MessageService.MessageService>();
        builder.Services.AddSingleton<MessagePublisher1>();

        var serviceProvider = builder.Services.BuildServiceProvider();

        var myService = serviceProvider.GetService<MessagePublisher1>();
        await myService.SendMessagesAsync();
    }
}