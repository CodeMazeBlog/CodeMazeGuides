using ActionFuncDelegatesInCsharp;
using ActionFuncDelegatesInCsharp.Logger;
using AutoFixture;
using Moq;

namespace Tests
{
    [TestClass]
    public class FuncDelegateTests
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
        public void WhenFuncDelegateInvoked_ThenLogMethodMustBeCalledTest()
        {
            var salary = _fixture.Create<double>();
            var taxRate = _fixture.Create<double>();

            _loggerMock.Setup(s => s.Log("CalculatedTax is :{0}", It.IsAny<double>())).Verifiable();
            _loggerMock.Setup(s => s.Log("Max salary is :{0}", Constants.MAX_SALARY)).Verifiable();

            var funcDelegate = new FuncDelegates(_loggerMock.Object);
            var result = funcDelegate.FuncDelegateUsage(salary, taxRate);
            var expected = salary * taxRate;

            _loggerMock.Verify();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenFuncDelegateInvokedWithNegativeSalary_ThenLogMethodMustBeCalledTest()
        {
            var salary = -20;
            var taxRate = _fixture.Create<double>();

            _loggerMock.Setup(s => s.Log("InvalidNetSalary")).Verifiable();
            _loggerMock.Setup(s => s.Log("Max salary is :{0}", Constants.MAX_SALARY)).Verifiable();

            var funcDelegate = new FuncDelegates(_loggerMock.Object);
            var result = funcDelegate.FuncDelegateUsage(salary, taxRate);
            var expected = -1;

            _loggerMock.Verify();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenFuncDelegateInvokedWithNegativeTaxRate_ThenLogMethodMustBeCalledTest()
        {
            var salary = _fixture.Create<double>();
            var taxRate = -0.12;

            _loggerMock.Setup(s => s.Log("InvalidTaxRate")).Verifiable();
            _loggerMock.Setup(s => s.Log("Max salary is :{0}", Constants.MAX_SALARY)).Verifiable();

            var funcDelegate = new FuncDelegates(_loggerMock.Object);
            var result = funcDelegate.FuncDelegateUsage(salary, taxRate);
            var expected = -2;

            _loggerMock.Verify();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenFuncDelegateInvokedWithZeroTaxRate_ThenLogMethodMustBeCalledTest()
        {
            var salary = _fixture.Create<double>();
            var taxRate = 0;

            _loggerMock.Setup(s => s.Log("InvalidTaxRate")).Verifiable();
            _loggerMock.Setup(s => s.Log("Max salary is :{0}", Constants.MAX_SALARY)).Verifiable();

            var funcDelegate = new FuncDelegates(_loggerMock.Object);
            var result = funcDelegate.FuncDelegateUsage(salary, taxRate);
            var expected = -2;

            _loggerMock.Verify();
            Assert.AreEqual(expected, result);
        }
    }
}