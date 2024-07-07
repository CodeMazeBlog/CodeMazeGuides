namespace RebusSagaPattern.Sagas.Messages;

public class OrderShippedEvent
{
    public Guid OrderId { get; set; }
}