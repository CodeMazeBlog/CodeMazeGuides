using Rebus.Sagas;

namespace RebusSagaPattern.Sagas.SagaData;

public class OrderSagaData : ISagaData
{
    public Guid Id { get; set; }
    public int Revision { get; set; }
        
    public Guid OrderId { get; set; }
    public bool IsOrderPlaced { get; set; }
    public bool IsPaymentProcessed { get; set; }
    public bool IsOrderShipped { get; set; }
}