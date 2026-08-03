using Producer.Controllers;
using Producer.Data;
using Producer.Dtos;
using Producer.RabbitMQ;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ASPNETCoreRabbitMQTests
{
    public class ASPNETCoreRabbitMQUnitTest
    {
        private readonly Mock<IMessageProducer> _messageProducer;
        private readonly List<Order> _orders;
        private readonly OrdersController _ordersController;

        public ASPNETCoreRabbitMQUnitTest()
        {
            _messageProducer = new Mock<IMessageProducer>();

            var dbContext = new Mock<IOrderDbContext>();
            _orders = new List<Order>();
            var mockSet = _orders.AsQueryable().BuildMockDbSet();
            dbContext.Setup(_ => _.Order).Returns(mockSet.Object);

            _ordersController = new OrdersController(dbContext.Object, _messageProducer.Object);
        }

        [Fact]
        public async Task GivenAnOrderDto_WhenCreateOrderIsCalled_ThenMessagePublishedToRabbitMQ()
        {
            // Arrange
            var orderDto = new OrderDto
            {
                ProductName = "Keyboard",
                Price = 99.99M,
                Quantity = 1
            };

            // Act
            await _ordersController.CreateOrder(orderDto);

            // Assert
            _messageProducer.Verify(m => m.SendMessage(
                It.Is<Order>(o => 
                o.ProductName == orderDto.ProductName 
                && o.Price == orderDto.Price 
                && o.Quantity == orderDto.Quantity
                )), Times.Once);
        }
    }
}