using AutoFixture;
using LogLevelsWithSerilog.Manager;
using Microsoft.Extensions.Logging;
using Moq;

namespace LogLevelsWithSerilogTests
{
    [TestClass]
    public class OrderManagerTests
    {
        private IOrderManager _orderManager;
        private Mock<ILogger<OrderManager>> _loggerMock;
        private IFixture _fixture;

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
            _loggerMock = new Mock<ILogger<OrderManager>>();
            _orderManager = new OrderManager(_loggerMock.Object);
        }

        [TestMethod]
        public void WhenCreateOrderCalledWithValidParameters_ThenResultMustNotBeNull()
        {
            var userId = _fixture.Create<int>();
            var basketId = _fixture.Create<int>();

            var result = _orderManager.CreateOrder(userId, basketId);

            _loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.AtLeast(2));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenCreateOrderCalledWithInvalidUserId_ThenResultMustBeNull()
        {
            var userId = -1;
            var basketId = _fixture.Create<int>();

            var result = _orderManager.CreateOrder(userId, basketId);

            _loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WhenCreateOrderCalledWithInvalidBasketId_ThenResultMustBeNull()
        {
            var userId = _fixture.Create<int>();
            var basketId = 0;

            var result = _orderManager.CreateOrder(userId, basketId);

            _loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void WhenCreateOrderCalledWithOrderedBasketId_ThenResultMustBeNull()
        {
            var userId = _fixture.Create<int>();
            var basketId = 100;

            var result = _orderManager.CreateOrder(userId, basketId);

            _loggerMock.Verify(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Critical,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            _loggerMock.Verify(x => x.Log(LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);

            Assert.IsNull(result);
        }
    }
}