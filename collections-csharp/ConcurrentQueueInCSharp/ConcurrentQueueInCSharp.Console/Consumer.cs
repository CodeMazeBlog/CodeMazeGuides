using ConcurrentQueueInCSharp.Models;

namespace ConcurrentQueueInCSharp
{
    public class Consumer
    {
        private readonly OrderMessageBus _messageBus;

        public Consumer(OrderMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public Task Process()
        {
            return Task.Factory.StartNew(() =>
            {
                Order order;
                string processId = Guid.NewGuid().ToString();

                while (_messageBus.Fetch(out order))
                {
                    Console.WriteLine($"ProcessId {processId} | Processing order {order.Id}");
                }
            });
        }
    }
}
