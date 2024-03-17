namespace CheckNumberInStringTests
{
    [TestClass]
    public class ExtractNumberTests
    {
        //-----------------RegEx Source Generators Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and $105.85";

            var expectedNumber = "2,101.45,105.85";

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void GivenStringWithNegativeNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and $105.85";

            var expectedNumber = "2,101.45,105.85";

            var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        //-----------------Linq Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingLinqMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and $105.85";

            var expectedNumber = "   2   101.45  105.85";

            var actualNumber = ExtractNumber.ExtractNumbersUsingLinq(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void GivenStringWithNegativeNumbers_WhenUsingLinqMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and $105.85";

            var expectedNumber = "   2   101.45  105.85";

            var actualNumber = ExtractNumber.ExtractNumbersUsingLinq(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        //-----------------StringBuilder Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and -$105.85";

            var expectedNumber = "2,101.45,105.85";

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilder(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and -$105.85";

            var expectedNumber = "2,101.45,105.85";

            var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilder(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        //-----------------Span Method 
        [TestMethod]
        public void GivenStringWithNumbers_WhenUsingSpantMethod_ThenReturnResultAreEqual()
        {
            var inputString = "Revenue for last 2 years is $101.45 and -$105.85";

            var expectedNumber = "2,101.45,105.85";

            var actualNumber = ExtractNumber.ExtractNumberUsingSpan(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [TestMethod]
        public void GivenStringWithoutNumbers_WhenUsingSpanMethod_ThenReturnResultAreEqual()
        {
            var inputString = "This has no numbers";

            var expectedNumber = "";

            var actualNumber = ExtractNumber.ExtractNumberUsingSpan(inputString);

            Assert.AreEqual(expectedNumber, actualNumber);
        }
    }
}