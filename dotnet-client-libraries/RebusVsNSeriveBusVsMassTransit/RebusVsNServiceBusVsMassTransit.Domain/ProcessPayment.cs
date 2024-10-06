namespace RebusVsNServiceBusVsMassTransit.Domain;

public class ProcessPayment
{
    public string TransactionId { get; set; }
    public string CreditCardNumber { get; set; }
}