﻿namespace Tests
{
    [TestClass]
    public class StringLengthCountTest
    {
        [TestMethod]
        public void WhenNumberIsGreaterThanZero_ThenReturnsTheRightNumberOfDigits()
        {
            const int number = 12345;

            int digits = DigitCounter.GetStringLengthCount(number);

            Assert.AreEqual(5, digits);
        }

        [TestMethod]
        public void WhenNumberIsLessThanZero_ThenReturnsTheRightNumberOfDigits()
        {
            const int number = -1234;

            int digits = DigitCounter.GetStringLengthCount(number);

            Assert.AreEqual(4, digits);
        }

        [TestMethod]
        public void WhenNumberIsZero_ThenReturns1()
        {
            const int number = 0;

            int digits = DigitCounter.GetStringLengthCount(number);

            Assert.AreEqual(1, digits);
        }
    }
}
