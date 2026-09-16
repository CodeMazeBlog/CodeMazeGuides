using ConcurrentQueueInCSharp.Models;

public class Producer(OrderMessageBus messageBus, int numberOfMessages)
{
    public Task Produce()
    {
        return Task.Run(() =>
        {
            for (int i = 0; i < numberOfMessages; i++)
            {
                messageBus.Add(new Order { Id = Guid.NewGuid().ToString() });
            }
        });
    }
}
