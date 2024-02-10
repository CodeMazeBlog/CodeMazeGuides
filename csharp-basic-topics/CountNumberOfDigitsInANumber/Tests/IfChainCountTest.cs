namespace Tests
{
    [TestClass]
    public class IfChainCountTest
    {
        [TestMethod]
        public void WhenNumberIsGreaterThanZero_ThenReturnsTheRightNumberOfDigits()
        {
            int number = 12345;
            var counter = new DigitCounter();

            int digits = counter.GetIfChainCount(number);
            Assert.AreEqual(5, digits);
        }

        [TestMethod]
        public void WhenNumberIsLessThanZero_ThenReturnsTheRightNumberOfDigits()
        {
            int number = -1234;
            var counter = new DigitCounter();

            int digits = counter.GetIfChainCount(number);
            Assert.AreEqual(4, digits);
        }

        [TestMethod]
        public void WhenNumberIsZero_ThenReturns1()
        {
            int number = 0;
            var counter = new DigitCounter();

            int digits = counter.GetIfChainCount(number);
            Assert.AreEqual(1, digits);
        }
    }
}
