namespace SagaPattern.Saga.Messages
{
    public class OrderCompleted : IEvent
    {
        public Guid OrderId { get; set; }
    }
}
