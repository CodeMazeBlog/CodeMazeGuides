namespace RebusSagaPattern.Sagas.Messages;

public class PaymentProcessedEvent
{
    public Guid OrderId { get; set; }
}