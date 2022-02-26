using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsingVariablesInsideStrings;

namespace Test
{
    [TestClass]
    public class UsingVariablesInsideStringsUnitTest
    {
        [TestMethod]
        public void StringConcatenation()
        {
            int myNumber = 5;
            string myText = "My number is " + myNumber + " but I can count way more";

            Assert.IsTrue(myText == "My number is 5 but I can count way more");
        }

        [TestMethod]
        public void StringConcatenationWithClass()
        {
            var number = new MyClass(3);
            string numberText1 = "My number is " + number;
            string numberText2 = "My number is " + number.ToString();

            Assert.IsTrue(numberText1 == "My number is 3");
            Assert.IsTrue(numberText2 == "My number is 3");
        }

        [TestMethod]
        public void StringFormat()
        {
            int apples = 10;
            int bananas = 6;

            string myString = string.Format("I have {0} apples, {1} bananas and {2} pears", apples, bananas, 3);

            Assert.IsTrue(myString == "I have 10 apples, 6 bananas and 3 pears");
        }

        [TestMethod]
        public void StringFormatMixed()
        {
            int apples = 10;
            int pears = 6;

            string myString = string.Format("I have {0} apples, {2} bananas and {1} pears. Did I mention I have {2} bananas?", apples, pears, 3);

            Assert.IsTrue(myString == "I have 10 apples, 3 bananas and 6 pears. Did I mention I have 3 bananas?");
        }

        [TestMethod]
        public void StringInterpolation()
        {
            int myApples = 2;
            int myPears = 5;
            int myBananas = 10;

            string myString = $"I have {myApples} apples, {myPears} pears and {(myApples > 2 ? myBananas : myBananas + 5)} bananas";

            Assert.IsTrue(myString == "I have 2 apples, 5 pears and 15 bananas");
        }

        [TestMethod]
        public void StringInterpolationEscapeBracket()
        {
            string word = "too";
            string myString = $"{{I am just a regular string}}! This other string is {word}.";

            Assert.IsTrue(myString == "{I am just a regular string}! This other string is too.");
        }
    }
}