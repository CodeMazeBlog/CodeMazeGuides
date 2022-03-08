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
            PriorityQueue<Order, int> priorityOrders = new PriorityQueue<Order, int>();

            var order1 = new Order("Ana", new string[] { "Chockolate", "Coffee" }, 20);
            var order2 = new Order("George", new string[] { "Juice", "Sandwich" }, 15);
            var order3 = new Order("Bob", new string[] { "Ice cream" }, 5);

            priorityOrders.Enqueue(order1, 2);
            priorityOrders.Enqueue(order2, 1);
            priorityOrders.Enqueue(order3, 3);

            Assert.Equal("George", priorityOrders.Peek().ClientName);
            Assert.Equal("George", priorityOrders.Dequeue().ClientName);
            Assert.Equal("Ana", priorityOrders.Dequeue().ClientName);
            Assert.Equal("Bob", priorityOrders.Dequeue().ClientName);
        }


    }
}