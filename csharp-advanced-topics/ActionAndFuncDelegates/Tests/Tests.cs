using ActionAndFuncDelegates;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly List<string> _names = new() {
            "Paul",
            "Aaron",
            "Amy",
            "World"
        };

        [TestMethod]
        public void GivenAName_WhenTrueIsSent_IsThisGoodbyeReturnsGoodbyeMesssage()
        {
            Func<bool, string, string> funcMsg = DelegateFunctionality.IsThisGoodBye;
            string result = funcMsg(true, "Paul");
            Assert.AreEqual("Goodbye, Paul", result);
        }

        [TestMethod]
        public void GivenAName_WhenFalseIsSent_IsThisGoodbyeReturnsHelloMesssage()
        {
            Func<bool, string, string> funcMsg = DelegateFunctionality.IsThisGoodBye;
            string result = funcMsg(false, "Aaron");
            Assert.AreEqual("Hello, Aaron", result);
        }

        [TestMethod]
        public void GivenListOfNames_WhenTrueIsSent_LambdaReturnsCountOfItemsStaringWithPrefix()
        {
            string prefix = "A";
            int result = DelegateFunctionality.CountOfListItemsContaining(_names, prefix, true);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GivenListOfNames_WhenFalseIsSent_LambdaReturnsCountOfItemsEndingWithSuffix()
        {
            string sufffix = "d";
            int result = DelegateFunctionality.CountOfListItemsContaining(_names, sufffix, false);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GivenAnInt_When5IsSent_AnonymousLessThanTenReturnsTrue()
        {
            bool result = DelegateFunctionality.AnonymousLessThanTen(5);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GivenAnInt_When15IsSent_AnonymousLessThanTenReturnsFalse()
        {
            bool result = DelegateFunctionality.AnonymousLessThanTen(15);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GivenAnInt_When5IsSent_LambdaLessThan10ReturnsTrue()
        {
            bool result = DelegateFunctionality.LambdaLessThanTen(5);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GivenAnInt_When15IsSent_LambdaLessThan10ReturnsFalse()
        {
            bool result = DelegateFunctionality.LambdaLessThanTen(15);
            Assert.AreEqual(false, result);
        }
    }
}