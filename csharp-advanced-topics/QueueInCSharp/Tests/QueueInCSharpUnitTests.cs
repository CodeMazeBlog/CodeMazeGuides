using QueueInCSharp;
using QueueInCSharp.Models;
using System.Collections.Generic;
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

        [Fact]
        public void whenUsePriorityQueue_thenQueueSortingIsDifferent()
        {
            PriorityQueue<Order, int> PriorityOrders = new PriorityQueue<Order, int>();

            var Order1 = new Order("Ana", new string[] { "Chockolate", "Coffee" }, 20);
            var Order2 = new Order("George", new string[] { "Juice", "Sandwich" }, 15);
            var Order3 = new Order("Bob", new string[] { "Ice cream" }, 5);

            PriorityOrders.Enqueue(Order1, 2);
            PriorityOrders.Enqueue(Order2, 1);
            PriorityOrders.Enqueue(Order3, 3);

            Assert.Equal("George", PriorityOrders.Peek().ClientName);
            Assert.Equal("George", PriorityOrders.Dequeue().ClientName);
            Assert.Equal("Ana", PriorityOrders.Dequeue().ClientName);
            Assert.Equal("Bob", PriorityOrders.Dequeue().ClientName);
        }


    }
}