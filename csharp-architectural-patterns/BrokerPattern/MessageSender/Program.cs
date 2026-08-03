using MessageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageSenderApp;

public class Program
{
    public static async Task Main()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<IMessageService, MessageService.MessageService>();
        builder.Services.AddSingleton<MessageSender>();

        var serviceProvider = builder.Services.BuildServiceProvider();

        var myService = serviceProvider.GetService<MessageSender>();
        await myService.SendMessagesAsync();
    }
}