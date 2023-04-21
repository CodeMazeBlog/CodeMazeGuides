namespace WithoutDelegate.Tests
{
    [TestClass]
    public class WithoutDelegateTests
    {
        [TestMethod]
        public void GivenTwoIntegers_WhenAdditionMethodIsCalled_ThenReturnTheSum()
        {
            var result = WithoutDelegate.Addition(5, 3);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void GivenTwoIntegers_WhenSubtractionMethodIsCalled_ThenReturnTheDifference()
        {
            var result = WithoutDelegate.Subtraction(5, 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenTwoIntegers_WhenMultiplicationMethodIsCalled_ThenReturnTheProduct()
        {
            var result = WithoutDelegate.Multiplication(5, 3);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void GivenAddOperation_WhenOperationMethodIsCalled_ThenReturnTheSum()
        {
            WithoutDelegate.Operation("add");
            // Assert expected behavior or output
        }

        [TestMethod]
        public void GivenSubtractOperation_WhenOperationMethodIsCalled_ThenReturnTheDifference()
        {
            WithoutDelegate.Operation("subtract");
            // Assert expected behavior or output
        }

        [TestMethod]
        public void GivenMultiplyOperation_WhenOperationMethodIsCalled_ThenReturnTheProduct()
        {
            WithoutDelegate.Operation("multiply");
            // Assert expected behavior or output
        }
    }
}