using ConcurrentQueueInCSharp.Models;
using System.Collections.Concurrent;

namespace ConcurrentQueueInCSharp
{
    public class OrderMessageBus
    {
        private readonly ConcurrentQueue<Order> _queue = new ConcurrentQueue<Order>();

        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }

        public void Add(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            _queue.Enqueue(order);
        }

        public bool Fetch(out Order order)
        {
            return _queue.TryDequeue(out order);
        }
    }
}
