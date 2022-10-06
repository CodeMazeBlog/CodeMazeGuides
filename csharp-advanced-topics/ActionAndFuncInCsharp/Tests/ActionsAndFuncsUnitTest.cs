using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionsAndFuncsUnitTest
    {
        [TestMethod]
        public void WhenActionReversesString_ThenStringIsReversed()
        {
            string message = "Hello";
            Action reverseMessage = () =>
            {
                message = string.Join("", message.Reverse());
            };

            reverseMessage();

            Assert.AreEqual("olleH", message);
        }

        [TestMethod]
        public void GivenActionMultipliesNumberBy5_WhenGivenNumberIs5_ThenResultIs25()
        {
            int result = 0;
            Action<int> multiplyBy5 = (int number) =>
            {
                result = number * 5;
            };

            multiplyBy5(5);

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void WhenFuncReturnsRandomNumber_ThenRandomNumberIsReturned()
        {
            Func<int> randomNumber = () =>
            {
                var rand = new Random();
                return rand.Next(1, 1000);
            };

            var result = randomNumber();

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void WhenFuncReturnsReversedString_ThenReversedStringReturned()
        {
            Func<string, string> reverse = (string toReverse) =>
            {
                return string.Join("", toReverse.Reverse());
            };

            var result = reverse("Hello World");

            Assert.AreEqual("dlroW olleH", result);
        }
    }
}