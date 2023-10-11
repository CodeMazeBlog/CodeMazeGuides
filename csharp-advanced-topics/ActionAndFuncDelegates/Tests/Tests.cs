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
        public void GivenAnInt_When35IsSent_AnonymousIsPersonOfLegalAgeReturnsTrue()
        {
            bool result = DelegateFunctionality.AnonymousIsPersonOfLegalAge(35);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GivenAnInt_When15IsSent_AnonymousIsPersonOfLegalAgeReturnsFalse()
        {
            bool result = DelegateFunctionality.AnonymousIsPersonOfLegalAge(15);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GivenAnInt_When35IsSent_LambdaIsPersonOfLegalAgeReturnsTrue()
        {
            bool result = DelegateFunctionality.LambdaIsPersonOfLegalAge(35);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GivenAnInt_When15IsSent_LambdaIsPersonOfLegalAgeReturnsFalse()
        {
            bool result = DelegateFunctionality.LambdaIsPersonOfLegalAge(15);
            Assert.AreEqual(false, result);
        }
    }
}