namespace SagaPattern.Saga.Messages
{
    public class PrepareShipment : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
