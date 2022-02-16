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
    public class ASPNETCoreRabbitMQTests
    {
        private readonly Mock<IMessagePublisher> _messagePublisher;
        private readonly List<Order> _orders;
        private readonly OrdersController _ordersController;

        public ASPNETCoreRabbitMQTests()
        {
            _messagePublisher = new Mock<IMessagePublisher>();

            var dbContext = new Mock<IOrderDbContext>();
            _orders = new List<Order>();
            var mockSet = _orders.AsQueryable().BuildMockDbSet();
            dbContext.Setup(_ => _.Order).Returns(mockSet.Object);

            _ordersController = new OrdersController(dbContext.Object, _messagePublisher.Object);
        }

        [Fact]
        public async Task CreateOrder_ValidOrderDto_PublishesMessageToRabbitMQ()
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
            _messagePublisher.Verify(m => m.SendMessage(
                It.Is<Order>(o => 
                o.ProductName == orderDto.ProductName 
                && o.Price == orderDto.Price 
                && o.Quantity == orderDto.Quantity
                )), Times.Once);
        }

        [Fact]
        public async Task UpdateOrder_ValidOrderDto_PublishesMessageToRabbitMQ()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                ProductName = "Keyboard",
                Price = 99.99M,
                Quantity = 1
            };

            _orders.Add(order);

            var orderDto = new OrderDto
            {
                ProductName = "Keyboard",
                Price = 99.99M,
                Quantity = 2
            };

            // Act
            await _ordersController.UpdateOrder(1, orderDto);

            // Assert
            _messagePublisher.Verify(m => m.SendMessage(
                It.Is<Order>(o =>
                o.ProductName == orderDto.ProductName
                && o.Price == orderDto.Price
                && o.Quantity == orderDto.Quantity
                )), Times.Once);
        }
    }
}