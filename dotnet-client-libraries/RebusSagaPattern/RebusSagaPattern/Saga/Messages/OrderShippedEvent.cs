namespace RebusSagaPattern.Saga.Messages;

public class OrderShippedEvent
{
    public Guid OrderId { get; set; }
}