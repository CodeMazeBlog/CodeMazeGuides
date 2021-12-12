using QueueInCSharp;
using Xunit;

namespace Tests
{
    public class QueueInCSharpUnitTests
    {
        [Fact]
        public void whenPeekElement_thenQueueCountIsSame()
        {
            var queueCount = QueueOperations.OrdersCount();
            var (firsOrder, numberOfRemainingOrders) = QueueOperations.GetOrderWithoutRemoving();
            Assert.Equal(queueCount, numberOfRemainingOrders);
        }

        [Fact]
        public void whenDequeuElement_thenQueueCountIsLessByOne()
        {
            var queueCount = QueueOperations.OrdersCount();
            var (firsOrder, numberOfRemainingOrders) = QueueOperations.GetOrderAndRemove();
            Assert.Equal(queueCount - 1, numberOfRemainingOrders);
        }

        [Fact]
        public void whenClearQueue_thenQueueCountIsZero()
        {
            var queueCount = QueueOperations.RemoveAllElements();
            Assert.Equal(0, queueCount);
        }


    }
}