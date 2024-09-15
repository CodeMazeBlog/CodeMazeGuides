namespace Events;

public record ThermostatTempChangeEvent(Guid CorrelationId, decimal Temperature);
