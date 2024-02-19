using CheckNumberInString;

namespace CheckNumberInStringTests
{
    [TestClass]
    public class ExtractNumberTests
    {
        //-----------------RegEx Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
        {
            string inputString = "The total revenue is $100.5";

            var expectedNumber = 100.5;

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreEqual(actualNumber,expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithNegativeNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
        {
            string inputString = "The total revenue is $-100.5";

            var expectedNumber = -100.5;

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingRegExMethod_ThenReturnResultAreNotEqual()
        {
            string inputString = "The total revenue is $-100.5";

            var expectedNumber = 100.5;

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreNotEqual(actualNumber, expectedNumber);
        }

        //-----------------Linq And CharIsDigit Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingLinqAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            string inputString = "The total revenue is $100";

            var expectedNumber = 100;

            var actualNumber = ExtractNumber.ExtractNumberUsingLinqAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingLinqAndCharIsDigitMethod_ThenReturnResultAreNotEqual()
        {
            string inputString = "The total revenue is $123";

            var expectedNumber = 100;

            var actualNumber = ExtractNumber.ExtractNumberUsingLinqAndCharIsDigit(inputString);

            Assert.AreNotEqual(actualNumber, expectedNumber);
        }

        //-----------------StringBuilder And CharIsDigit Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            string inputString = "The total revenue is $100";

            var expectedNumber = 100;

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreNotEqual()
        {
            string inputString = "The total revenue is $123";

            var expectedNumber = 100;

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString);

            Assert.AreNotEqual(actualNumber, expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            string inputString = "The is a sample";

            var expectedNumber = 0;

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }
    }
}