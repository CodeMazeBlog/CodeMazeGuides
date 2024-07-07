namespace RebusSagaPattern.Saga.Messages;

public class PaymentProcessedEvent
{
    public Guid OrderId { get; set; }
}