namespace RebusSagaPattern.Sagas.Messages;

public class ProcessPaymentCommand
{
    public Guid OrderId { get; set; }
}