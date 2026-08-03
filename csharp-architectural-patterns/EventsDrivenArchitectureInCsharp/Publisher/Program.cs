using Events;
using MassTransit;

namespace Publisher;

public class Program
{
    static async Task Main()
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq();

        await busControl.StartAsync();

        Console.WriteLine("Home Automation system is running.");

        while (true)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Turn Lights On");
            Console.WriteLine("2. Turn Lights Off");
            Console.WriteLine("3. Adjust Thermostat");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ControlLights(busControl, LightState.On);
                    break;
                case "2":
                    await ControlLights(busControl, LightState.Off);
                    break;
                case "3":
                    Console.WriteLine("Enter new thermostat temperature:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newTemperature))
                    {
                        await ControlThermostat(busControl, newTemperature);
                    }
                    else
                    {
                        Console.WriteLine("Invalid temperature input.");
                    }
                    break;
                default:
                    Console.WriteLine("Please select out of the given options.");
                    break;
            }
        }
    }

    static async Task ControlLights(IBusControl busControl, LightState state)
    {
        var lightEndpoint = await busControl.GetSendEndpoint(new Uri("rabbitmq://localhost/lights"));
        await lightEndpoint.Send<LightSwitchEvent>(new { State = state });

        Console.WriteLine($"Lights switched {state}");
    }

    static async Task ControlThermostat(IBusControl busControl, decimal newTemperature)
    {
        var thermostatEndpoint = await busControl.GetSendEndpoint(new Uri("rabbitmq://localhost/thermostat"));
        await thermostatEndpoint.Send<ThermostatTempChangeEvent>(new { NewTemperature = newTemperature });

        Console.WriteLine($"Thermostat adjusted to {newTemperature}°C");
    }
}