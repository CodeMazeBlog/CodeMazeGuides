using System.Collections.Concurrent;
using ConcurrentQueueInCSharp.Models;

public class OrderMessageBus
{
    private readonly ConcurrentQueue<Order> _queue = new();

    public int Count => _queue.Count;

    public void Add(Order? order)
    {
        ArgumentNullException.ThrowIfNull(order);

        _queue.Enqueue(order);
    }

    public bool Fetch(out Order? order) => _queue.TryDequeue(out order);
}
