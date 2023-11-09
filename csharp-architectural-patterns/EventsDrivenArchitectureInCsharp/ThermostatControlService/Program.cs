using MassTransit;

namespace ThermostatControlService;

public class Program
{
    static async Task Main()
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.ReceiveEndpoint("thermostat", e =>
            {
                e.Consumer<ThermostatEventSubscriber>();
            });
        });

        await busControl.StopAsync();

        Console.WriteLine("Thermostat control service is running. Press any key to exit.");
        Console.ReadLine();

        await busControl.StopAsync();
    }
}