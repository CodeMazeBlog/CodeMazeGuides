namespace SagaPattern.Saga.Messages
{
    public class StartOrder : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
