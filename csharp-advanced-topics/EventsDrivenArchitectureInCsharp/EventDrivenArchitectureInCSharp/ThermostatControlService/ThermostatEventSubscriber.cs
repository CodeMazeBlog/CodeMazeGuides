using Events;
using MassTransit;

namespace ThermostatControlService;

public class ThermostatEventSubscriber : IConsumer<ThermostatTempChangeEvent>
{
    public async Task Consume(ConsumeContext<ThermostatTempChangeEvent> context)
    {
        var thermostatEvent = context.Message;

        bool success = await AdjustThermostatAsync(thermostatEvent);

        if (success)
            Console.WriteLine($"Thermostat Control: Temperature changed to {thermostatEvent.NewTemperature}°C successfully.");
        else
            Console.WriteLine($"Failed to adjust thermostat to {thermostatEvent.NewTemperature}°C");

    }

    public static async Task<bool> AdjustThermostatAsync(ThermostatTempChangeEvent thermoStatEvent)
    {
        try
        {
            // Simulating a delay to represent the time taken to adjust the thermostat.
            await Task.Delay(TimeSpan.FromSeconds(2));

            Console.WriteLine($"Adjusting thermostat to {thermoStatEvent.NewTemperature}°C...");

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adjusting thermostat: {ex.Message}");

            return false;
        }
    }
}
