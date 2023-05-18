using Microsoft.Extensions.Logging;
using Moq;
using SwashbuckleVsNSwag.Models.Orders;
using SwashbuckleVsNSwag.NSwag.Controllers;
using SwashbuckleVsNSwag.Repositories.OrderRepository;

namespace SwashbuckleVsNSwag.NSwag.Tests
{
    public class OrderConsollerTest
    {
        private Mock<ILogger<OrderController>> _logger;
        private Mock<IOrderRepository> _orderRepository;
        private OrderController _controller;

        [SetUp]
        public void Setup()
        {
            _logger= new Mock<ILogger<OrderController>>();
            _orderRepository= new Mock<IOrderRepository>();

            _controller = new OrderController(_logger.Object, _orderRepository.Object);
        }

        [Test]
        public void WhenGettingOrderById_ThenReturnCorrectOrder()
        {
            var order = new Order
            {
                OrderId = new Guid("59d37b43-01c4-4bc7-8ccf-7d67bb10229c")
            };
            _orderRepository.Setup(r => r.GetById(It.IsAny<Guid>())).Returns(order);

            var result = _controller.Get(order.OrderId).Value;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.OrderId, Is.EqualTo(order.OrderId));
        }

        [Test]
        public void WhenAddingOrder_ThenOrderIsStored()
        {
            var order = new Order
            {
                OrderId = new Guid("59d37b43-01c4-4bc7-8ccf-7d67bb10229c"),
            };

            _controller.Post(order);

            _orderRepository.Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
        }
    }
}