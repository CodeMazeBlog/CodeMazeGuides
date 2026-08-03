namespace SagaPattern.Saga.Messages
{
    public class ProcessPayment : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
