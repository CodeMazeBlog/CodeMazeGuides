using ConsumerApp;
using ConsumerApp.Application.cs;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main()
    {
        var startUp = new StartUp();
        var host = startUp.HostBuild();

        var consumer = host.Services.GetRequiredService<ProgramApplication>();

        await consumer.SignIn();
        await consumer.RunAsync();
    }
}
