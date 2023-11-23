namespace Events;

public record LightSwitchEvent(Guid CorrelationId, LightState State);