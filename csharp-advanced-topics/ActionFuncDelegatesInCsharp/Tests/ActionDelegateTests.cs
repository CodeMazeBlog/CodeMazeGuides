using ActionFuncDelegatesInCsharp;
using ActionFuncDelegatesInCsharp.Logger;
using AutoFixture;
using Moq;

namespace Tests
{
    [TestClass]
    public class ActionDelegateTests
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
        public void WhenActionDelegateWithLambdaExpressionInvoked_ThenLogMethodMustBeCalledSumTest()
        {
            var a = _fixture.Create<int>();
            var b = _fixture.Create<int>();

            _loggerMock.Setup(s => s.Log("{0}+{1}={2}", a, b, a + b)).Verifiable();

            var actionDelegate = new ActionDelegates(_loggerMock.Object);
            actionDelegate.DelegateWithLambdaExpressionUsage(a, b, "+");

            _loggerMock.Verify();
        }

        [TestMethod]
        public void WhenActionDelegateWithLambdaExpressionInvoked_ThenLogMethodMustBeCalledMultiplyTest()
        {
            var a = _fixture.Create<int>();
            var b = _fixture.Create<int>();

            _loggerMock.Setup(s => s.Log("{0}*{1}={2}", a, b, a * b)).Verifiable();

            var actionDelegate = new ActionDelegates(_loggerMock.Object);
            actionDelegate.DelegateWithLambdaExpressionUsage(a, b, "*");

            _loggerMock.Verify();
        }

        [TestMethod]
        public void WhenActionDelegateWithLambdaExpressionInvoked_ThenLogMethodMustBeCalledNotSupportedTest()
        {
            var a = _fixture.Create<int>();
            var b = _fixture.Create<int>();

            _loggerMock.Setup(s => s.Log("Operation Not Supported")).Verifiable();

            var actionDelegate = new ActionDelegates(_loggerMock.Object);
            actionDelegate.DelegateWithLambdaExpressionUsage(a, b, "#");

            _loggerMock.Verify();
        }

        [TestMethod]
        public void WhenActionDelegateWithReferenceMethodInvoked_ThenLogMethodMustBeCalledMessageTest()
        {
            var message = _fixture.Create<string>();

            _loggerMock.Setup(s => s.Log("INF:{0}", message)).Verifiable();

            var actionDelegate = new ActionDelegates(_loggerMock.Object);
            actionDelegate.DelegateWithReferenceMethodUsage(message);

            _loggerMock.Verify();
        }

        [TestMethod]
        public void WhenActionDelegateWithReferenceMethodInvoked_ThenLogMethodMustBeCalledEmptyMessageTest()
        {
            _loggerMock.Setup(s => s.Log("EmptyMessage")).Verifiable();

            var actionDelegate = new ActionDelegates(_loggerMock.Object);
            actionDelegate.DelegateWithReferenceMethodUsage("");

            _loggerMock.Verify();
        }

        [TestMethod]
        public void WhenActionDelegateWithChainMethodInvoked_ThenLogMethodMustBeCalledMultiTimesTest()
        {
            var testValue = _fixture.Create<int>();
            _loggerMock.Setup(s => s.Log("Your age is :{0}", testValue)).Verifiable();
            _loggerMock.Setup(s => s.Log("Your Exam score is :{0}", Math.Min(testValue * 1.8, 100))).Verifiable();
            _loggerMock.Setup(s => s.Log("This number is {0}", testValue % 2 != 0 ? "ODD" : "EVEN")).Verifiable();

            var actionDelegate = new ActionDelegates(_loggerMock.Object);
            actionDelegate.DelegateChainedUsage(testValue);

            _loggerMock.Verify();
        }
    }
}