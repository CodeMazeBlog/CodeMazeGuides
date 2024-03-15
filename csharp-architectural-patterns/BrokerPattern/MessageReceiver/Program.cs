using MessageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageReceiverApp;

public static class Program
{
    public static async Task Main()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddSingleton<IMessageService, MessageService.MessageService>();
        builder.Services.AddSingleton<MessageReceiver>();

        var serviceProvider = builder.Services.BuildServiceProvider();

        var myService = serviceProvider.GetService<MessageReceiver>();
        await myService.ReceiveMessagesAsync();
    }
}