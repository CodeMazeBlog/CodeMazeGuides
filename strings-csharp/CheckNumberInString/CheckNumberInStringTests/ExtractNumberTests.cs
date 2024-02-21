namespace CheckNumberInStringTests
{
    [TestClass]
    public class ExtractNumberTests
    {
        //-----------------RegEx Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
        {
            var inputString = "The total revenue is $100.5";

            var expectedNumber = 100.5;

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreEqual(actualNumber,expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithNegativeNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
        {
            var inputString = "The total revenue is $-100.5";

            var expectedNumber = -100.5;

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        //-----------------Linq And CharIsDigit Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingLinqAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            var inputString = "The total revenue is $101.45";

            var expectedNumber = 101.45;

            var actualNumber = ExtractNumber.ExtractNumberUsingLinqAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithNegativeNumbers_WhenUsingLinqAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            var inputString = "The total revenue is $-100.65";

            var expectedNumber = -100.65;

            var actualNumber = ExtractNumber.ExtractNumberUsingLinqAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        //-----------------StringBuilder And CharIsDigit Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            var inputString = "The total revenue is $-132.23";

            var expectedNumber = -132.23;

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }

        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            var inputString = "This has no numbers";

            var expectedNumber = 0;

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilderAndCharIsDigit(inputString);

            Assert.AreEqual(actualNumber, expectedNumber);
        }
    }
}