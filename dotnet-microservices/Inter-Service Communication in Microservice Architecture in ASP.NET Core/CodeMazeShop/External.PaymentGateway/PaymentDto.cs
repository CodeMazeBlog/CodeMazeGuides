namespace External.PaymentGateway;

public class PaymentDto
{
    public Guid OrderId { get; set; }
    public int Total { get; set; }

    public string CardNumber { get; set; }

    public string CardName { get; set; }

    public string CardExpiration { get; set; }
}