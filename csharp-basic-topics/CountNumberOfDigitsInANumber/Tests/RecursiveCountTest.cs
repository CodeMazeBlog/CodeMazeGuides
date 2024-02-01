using CountNumberOfDigitsInANumber;

namespace Tests
{
    [TestClass]
    public class RecursiveCountTest
    {
        [TestMethod]
        public void WhenNumberIsGreaterThanZero_ThenReturnsTheRightNumberOfDigits()
        {
            int number = 12345;
            var counter = new DigitCounter();

            int digits = counter.GetRecursiveCount(number);
            Assert.AreEqual(5, digits);
        }

        [TestMethod]
        public void WhenNumberIsLessThanZero_ThenReturnsTheRightNumberOfDigits()
        {
            int number = -1234;
            var counter = new DigitCounter();

            int digits = counter.GetRecursiveCount(number);
            Assert.AreEqual(4, digits);
        }

        [TestMethod]
        public void WhenNumberIsZero_ThenReturns1()
        {
            int number = 0;
            var counter = new DigitCounter();

            int digits = counter.GetRecursiveCount(number);
            Assert.AreEqual(1, digits);
        }
    }
}
