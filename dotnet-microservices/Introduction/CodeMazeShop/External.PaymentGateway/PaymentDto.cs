namespace External.PaymentGateway;

public class PaymentDto
{
    public Guid OrderId { get; set; }
    public int Total { get; set; }
}