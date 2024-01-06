using MessageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessagePublisherApp2;

public static class Program
{
    public static async Task Main()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<IMessageService, MessageService.MessageService>();
        builder.Services.AddSingleton<MessagePublisher2>();

        var serviceProvider = builder.Services.BuildServiceProvider();

        var myService = serviceProvider.GetService<MessagePublisher2>();
        await myService.SendMessagesAsync();
    }
}