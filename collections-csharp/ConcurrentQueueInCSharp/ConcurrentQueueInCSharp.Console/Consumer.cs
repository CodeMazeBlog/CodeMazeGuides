public class Consumer(OrderMessageBus messageBus)
{
    public Task Process(CancellationToken token)
    {
        return Task.Run(async () =>
        {
            while (!token.IsCancellationRequested)
            {
                if (messageBus.Fetch(out var order))
                {
                    Console.WriteLine($"ProcessId {Task.CurrentId} | Processing order {order!.Id}");
                    Thread.Sleep(200);
                }
                else
                {
                    await Task.Delay(50, CancellationToken.None);
                }
            }
        }, CancellationToken.None);
    }
}
