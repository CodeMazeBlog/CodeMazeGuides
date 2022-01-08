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
            string input = "345 ";
            int expected = 345;
            int actual = 0;
            try
            {
                actual = int.Parse(input);
                
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error");
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassNullStringToIntParse_ThenNullException()
        {
            string input = null;
            string expected = "ArgumentNullException";
            int output;
            string actual = null;
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
            string input = "345 ";
            int expected = 345;
            int actual = Convert.ToInt32(input);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassNullStringToConvertToInt_ThenZero()
        {
            string input = null;
            int expected = 0;
            int actual = Convert.ToInt32(input);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenPassCorrectFromatedStringToIntTryParse_ThenCorrectOutputIntegerWIthReturnTrue()
        {
            string input = "345 ";
            int expected = 345;
            int actual ;
            bool expectedSuccess = true;
            bool actualSuccess = int.TryParse(input, out actual);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedSuccess, actualSuccess);
        }

        [TestMethod]
        public void WhenPassNullStringToIntTryParse_ThenReturnFalse()
        {
            string input = null;
            int expected = 0;
            int actual;
            bool expectedSuccess = false;
            bool actualSuccess = int.TryParse(input, out actual);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedSuccess, actualSuccess);
        }
    }
}