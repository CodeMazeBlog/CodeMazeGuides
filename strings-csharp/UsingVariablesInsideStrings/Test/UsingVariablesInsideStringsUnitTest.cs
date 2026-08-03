using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsingVariablesInsideStrings;

namespace Test
{
    [TestClass]
    public class UsingVariablesInsideStringsUnitTest
    {
        [TestMethod]
        public void WhenConcatenatingString_ThenCorrectOutput()
        {
            var myNumber = 5;
            var myText = "My number is " + myNumber + " but I can count way more";

            Assert.IsTrue(myText == "My number is 5 but I can count way more");
        }

        [TestMethod]
        public void WhenConcatenatingStringWithClass_ThenCorrectOutput()
        {
            var number = new MyClass(3);
            var numberText1 = "My number is " + number;
            var numberText2 = "My number is " + number.ToString();

            Assert.IsTrue(numberText1 == "My number is 3");
            Assert.IsTrue(numberText2 == "My number is 3");
        }

        [TestMethod]
        public void WhenUsingStringFormat_ThenCorrectOutput()
        {
            var apples = 10;
            var bananas = 6;

            var myString = string.Format("I have {0} apples, {1} bananas and {2} pears", apples, bananas, 3);

            Assert.IsTrue(myString == "I have 10 apples, 6 bananas and 3 pears");
        }

        [TestMethod]
        public void WhenUsingMixedStringFormat_ThenCorrectOutput()
        {
            var apples = 10;
            var pears = 6;

            var myString = string.Format("I have {0} apples, {2} bananas and {1} pears. Did I mention I have {2} bananas?", apples, pears, 3);

            Assert.IsTrue(myString == "I have 10 apples, 3 bananas and 6 pears. Did I mention I have 3 bananas?");
        }

        [TestMethod]
        public void WhenUsingStringInterpolation_ThenCorrectOutput()
        {
            var myApples = 2;
            var myPears = 5;
            var myBananas = 10;

            string myString = $"I have {myApples} apples, {myPears} pears and {(myApples > 2 ? myBananas : myBananas + 5)} bananas";

            Assert.IsTrue(myString == "I have 2 apples, 5 pears and 15 bananas");
        }

        [TestMethod]
        public void WhenUsingStringInterpolationWithEscapeBracket_ThenCorrectOutput()
        {
            var word = "too";
            var myString = $"{{I am just a regular string}}! This other string is {word}.";

            Assert.IsTrue(myString == "{I am just a regular string}! This other string is too.");
        }
    }
}