namespace ConcurrentQueueInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderMessageBus messageBus = new OrderMessageBus();

            Producer producer1 = new Producer(messageBus, 10);
            Producer producer2 = new Producer(messageBus, 10);
            Producer producer3 = new Producer(messageBus, 10);

            Consumer consumer1 = new Consumer(messageBus);
            Consumer consumer2 = new Consumer(messageBus);
            Consumer consumer3 = new Consumer(messageBus);
            
            Task.WaitAll(
                producer1.Produce(), producer2.Produce(), producer3.Produce(), 
                consumer1.Process(), consumer2.Process(), consumer3.Process());
        }
    }
}