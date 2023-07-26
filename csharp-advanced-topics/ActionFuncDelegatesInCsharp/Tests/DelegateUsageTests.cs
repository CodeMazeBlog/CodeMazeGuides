using ActionFuncDelegatesInCsharp;
using ActionFuncDelegatesInCsharp.Logger;
using AutoFixture;
using Moq;

namespace Tests
{
    [TestClass]
    public class DelegateUsageTests
    {
        private Mock<ILogger> _loggerMock;
        private IFixture _fixture;

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
            _loggerMock = new Mock<ILogger>();
        }

        [TestMethod]
        public void WhenDelegateInvokedWithMessage_ThenReferenceMethodMustBeCalled()
        {
            var message = _fixture.Create<string>();

            _loggerMock.Setup(s => s.Log("Delegate LengthFinder invoked with message :{0}", message)).Verifiable();
            _loggerMock.Setup(s => s.Log("message length is :{0}", message.Length)).Verifiable();

            var delegateUsage = new DelegateUsage(_loggerMock.Object);
            var result = delegateUsage.DelegateAsCallbackParameterUsage(message);
            var expected = message.Length;

            _loggerMock.Verify();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenDelegateInvokedWithNoMessage_ThenResultMustBeZero()
        {
            var message = string.Empty;

            _loggerMock.Setup(s => s.Log("Delegate LengthFinder invoked with message :{0}", message)).Verifiable();
            _loggerMock.Setup(s => s.Log("message length is :{0}", message.Length)).Verifiable();

            var delegateUsage = new DelegateUsage(_loggerMock.Object);
            var result = delegateUsage.DelegateAsCallbackParameterUsage(message);
            var expected = 0;

            _loggerMock.Verify();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenDelegateInvokedWithEvent_ThenReferenceMethodsMustBeCalled()
        {
            var gear = _fixture.Create<int>();
            var busSpeed = (5.2 + gear) * gear * gear;
            var truckSpeed = (3.1 + gear) * gear * gear;

            _loggerMock.Setup(s => s.Log("Bus accelerated on gear {0} with {1} km/h", gear, busSpeed)).Verifiable();
            _loggerMock.Setup(s => s.Log("Truck accelerated on gear {0} with {1} km/h", gear, truckSpeed)).Verifiable();

            var delegateUsage = new DelegateUsage(_loggerMock.Object);
            delegateUsage.DelegateWithEventUsage(gear);

            _loggerMock.Verify();
        }
    }
}