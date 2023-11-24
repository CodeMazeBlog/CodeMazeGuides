public class Consumer
{
    private readonly OrderMessageBus _messageBus;

    public Consumer(OrderMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public Task Process()
    {
        return Task.Run(() =>
        {
            while (_messageBus.Fetch(out var order))
            {
                Console.WriteLine($"ProcessId {Task.CurrentId} | Processing order {order.Id}");
                Thread.Sleep(200);
            }
        });
    }
}
