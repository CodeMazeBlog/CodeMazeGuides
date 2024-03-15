using MassTransit;

namespace LightControlService;

public class Program
{
    static async Task Main()
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.ReceiveEndpoint("lights", e =>
            {
                e.Consumer<LightSwitchEventSubscriber>();
            });
        });

        await busControl.StartAsync();

        Console.WriteLine("Light control service is running. Press any key to exit.");
        Console.ReadLine();

        await busControl.StopAsync();
    }
}