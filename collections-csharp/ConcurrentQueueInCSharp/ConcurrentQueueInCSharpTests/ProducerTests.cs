using ConcurrentQueueInCSharp;
using ConcurrentQueueInCSharp.Models;

namespace ConcurrentQueueInCSharpTests
{
    public class MessageBusTests
    {
        private OrderMessageBus _messageBus;

        [SetUp]
        public void Setup()
        {
            _messageBus = new OrderMessageBus();
        }

        [Test]
        public void WhenAddingNewOrder_ThenOrderIsStoredInQueue()
        {
            var order = new Order
            {
                Id = "9425f6b8-e57d-494c-a4c3-9e70849135a9"
            };

            _messageBus.Add(order);

            Assert.That(_messageBus.Count, Is.EqualTo(1));
        }

        [Test]
        public void WhenAddingEmptyOrder_ThenArgumentNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => _messageBus.Add(null));
        }

        [Test]
        public void WhenFetchingOrder_ThenOrderIsReturned()
        {
            var order = new Order
            {
                Id = "9425f6b8-e57d-494c-a4c3-9e70849135a9"
            };

            _messageBus.Add(order);

            var result = _messageBus.Fetch(out var returnedOrder);

            Assert.That(result, Is.True);
            Assert.That(returnedOrder, Is.Not.Null);
            Assert.That(returnedOrder.Id, Is.EqualTo(order.Id));
        }
    }
}