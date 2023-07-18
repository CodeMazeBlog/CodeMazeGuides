using Moq;
using NServiceBus.Testing;
using SagaPattern.Models;
using SagaPattern.Repositories;
using SagaPattern.Saga.Handlers;
using SagaPattern.Saga.Messages;

namespace SagaPatternTests
{
    public class OrderSagaTests
    {
        private Mock<IOrderRepository> _repositoryMock;
        private readonly Guid _orderId = Guid.Parse("60517f32-50af-4a87-a91a-3132ae30f2ac");

        [SetUp]
        public void Setup()
        {
            var order = new Order
            {
                OrderId = _orderId,
                Price = 150,
                Status = OrderStatus.OrderCreated
            };

            _repositoryMock = new Mock<IOrderRepository>();
            _repositoryMock.Setup(x => x.GetOrderById(It.IsAny<Guid>())).ReturnsAsync(order);
        }

        [Test]
        public async Task WhenStartOrderMessageIsReceived_ThenProcessPaymentMessageIsSend()
        {
            var handler = new OrderSaga(_repositoryMock.Object);
            handler.Data = new SagaPattern.Saga.SagaData.OrderSagaData();

            var context = new TestableMessageHandlerContext();
            var startOrderMessage = new StartOrder
            {
                OrderId = _orderId
            };

            await handler.Handle(startOrderMessage, context).ConfigureAwait(false);

            Assert.AreEqual(1, context.SentMessages.Length);
            Assert.IsInstanceOf<ProcessPayment>(context.SentMessages[0].Message);
        }

        [Test]
        public async Task WhenStartOrderMessageIsReceived_ThenOrderIdInSagaDataShouldBeSet()
        {
            var handler = new OrderSaga(_repositoryMock.Object);
            handler.Data = new SagaPattern.Saga.SagaData.OrderSagaData();

            var context = new TestableMessageHandlerContext();
            var startOrderMessage = new StartOrder
            {
                OrderId = _orderId
            };

            await handler.Handle(startOrderMessage, context).ConfigureAwait(false);

            Assert.AreEqual(_orderId, handler.Data.OrderId);
        }

        [Test]
        public async Task WhenProcessPaymentMessageIsReceived_ThenPrepareShipmentMessageIsSend()
        {
            var handler = new OrderSaga(_repositoryMock.Object);
            handler.Data = new SagaPattern.Saga.SagaData.OrderSagaData()
            {
                OrderId = _orderId
            };

            var context = new TestableMessageHandlerContext();
            var startOrderMessage = new ProcessPayment
            {
                OrderId = _orderId
            };

            await handler.Handle(startOrderMessage, context).ConfigureAwait(false);

            Assert.AreEqual(1, context.SentMessages.Length);
            Assert.IsInstanceOf<PrepareShipment>(context.SentMessages[0].Message);
        }

        [Test]
        public async Task WhenProcessPaymentMessageIsReceived_ThenSagaDataIsUpdated()
        {
            var handler = new OrderSaga(_repositoryMock.Object);
            handler.Data = new SagaPattern.Saga.SagaData.OrderSagaData
            {
                OrderId = _orderId
            };

            var context = new TestableMessageHandlerContext();
            var startOrderMessage = new ProcessPayment
            {
                OrderId = _orderId
            };

            await handler.Handle(startOrderMessage, context).ConfigureAwait(false);

            Assert.AreEqual(true, handler.Data.PaymentProcessed);
        }

        [Test]
        public async Task WhenPrepareShipmentMessageIsReceived_ThenOrderCompletedEventIsPublished()
        {
            var handler = new OrderSaga(_repositoryMock.Object);
            handler.Data = new SagaPattern.Saga.SagaData.OrderSagaData()
            {
                OrderId = _orderId
            };

            var context = new TestableMessageHandlerContext();
            var startOrderMessage = new PrepareShipment
            {
                OrderId = _orderId
            };

            await handler.Handle(startOrderMessage, context).ConfigureAwait(false);

            Assert.AreEqual(1, context.PublishedMessages.Length);
            Assert.IsInstanceOf<OrderCompleted>(context.PublishedMessages[0].Message);
        }

        [Test]
        public async Task WhenPrepareShipmentMessageIsReceived_ThenSagaDataIsUpdated()
        {
            var handler = new OrderSaga(_repositoryMock.Object);
            handler.Data = new SagaPattern.Saga.SagaData.OrderSagaData()
            {
                OrderId = _orderId
            };

            var context = new TestableMessageHandlerContext();
            var startOrderMessage = new PrepareShipment
            {
                OrderId = _orderId
            };

            await handler.Handle(startOrderMessage, context).ConfigureAwait(false);

            Assert.AreEqual(true, handler.Data.ShipmentPrepared);
        }
    }
}