using Events;
using MassTransit;

namespace ThermostatControlService;

public class ThermostatEventSubscriber : IConsumer<ThermostatTempChangeEvent>
{
    public async Task Consume(ConsumeContext<ThermostatTempChangeEvent> context)
    {
        var thermostatEvent = context.Message;

        var isSuccessful = await AdjustThermostatAsync(thermostatEvent);

        if (isSuccessful)
            Console.WriteLine($"Temperature changed to {thermostatEvent.Temperature}°C successfully.");
        else
            Console.WriteLine($"Failed to adjust thermostat to {thermostatEvent.Temperature}°C");

    }

    public static async Task<bool> AdjustThermostatAsync(ThermostatTempChangeEvent thermostatEvent)
    {
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            Console.WriteLine($"Adjusting thermostat to {thermostatEvent.Temperature}°C...");

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adjusting thermostat: {ex.Message}");

            return false;
        }
    }
}
