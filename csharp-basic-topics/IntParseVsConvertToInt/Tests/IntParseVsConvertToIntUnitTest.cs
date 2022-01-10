using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class IntParseVsConvertToIntUnitTest
    {
        [TestMethod]
        public void WhenPassCorrectFromatedStringToIntParse_ThenCorrectOutputInteger()
        {
            var input = "345 ";
            var expected = 345;
            var actual = 0;
            try
            {
                actual = int.Parse(input);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException");
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassNullStringToIntParse_ThenNullException()
        {
            string input = null;
            var expected = "ArgumentNullException";
            var output = 0;
            var actual = string.Empty;
            try
            {
                output = int.Parse(input);

            }
            catch (ArgumentNullException ex)
            {
                actual = "ArgumentNullException";
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassCorrectFromatedStringToConvertToInt_ThenCorrectOutputInteger()
        {
            var input = "345 ";
            var expected = 345;
            var actual = Convert.ToInt32(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassNullStringToConvertToInt_ThenZero()
        {
            string input = null;
            var expected = 0;
            var actual = Convert.ToInt32(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassCorrectFromatedStringToIntTryParse_ThenCorrectOutputIntegerWIthReturnTrue()
        {
            var input = "345 ";
            var expected = 345;
            var expectedSuccess = true;
            var actualSuccess = int.TryParse(input, out var actual);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedSuccess, actualSuccess);
        }

        [TestMethod]
        public void WhenPassNullStringToIntTryParse_ThenReturnFalse()
        {
            string input = null;
            var expected = 0;
            var expectedSuccess = false;
            var actualSuccess = int.TryParse(input, out var actual);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedSuccess, actualSuccess);
        }
    }
}