namespace Events;

public class ThermostatTempChangeEvent
{
    public Guid CorrelationId { get; set; }
    public decimal NewTemperature { get; set; }
}
