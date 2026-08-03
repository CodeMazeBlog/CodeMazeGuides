using Events;
using LightControlService;
using ThermostatControlService;

namespace Tests;

public class Test
{
    [Fact]
    public async Task GivenLightSwitchEvent_WhenControlLightsAsyncSucceeds_ThenLightStateChanged()
    {
        var lightEvent = new LightSwitchEvent(Guid.NewGuid(), LightState.On);
        var success = await LightSwitchEventSubscriber.ControlLightsAsync(lightEvent);

        Assert.True(success);
    }

    [Fact]
    public async Task GivenThermostatTempChangeEvent_WhenAdjustThermostatAsyncSucceeds_ThenTemperatureChanged()
    {
        var thermostatEvent = new ThermostatTempChangeEvent(Guid.NewGuid(), 33.5m);
        var success = await ThermostatEventSubscriber.AdjustThermostatAsync(thermostatEvent);

        Assert.True(success);
    }
}