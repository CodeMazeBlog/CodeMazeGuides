using ConcurrentQueueInCSharp.Models;

public class Producer
{
    private readonly OrderMessageBus _messageBus;
    private readonly int _numberOfMessages;

    public Producer(OrderMessageBus messageBus, int numberOfMessages)
    {
        _messageBus = messageBus;
        _numberOfMessages = numberOfMessages;
    }

    public Task Produce()
    {
        return Task.Run(() =>
        {
            for (int i = 0; i < _numberOfMessages; i++)
            {
                _messageBus.Add(new Order { Id = Guid.NewGuid().ToString() });
            }
        });
    }
}
