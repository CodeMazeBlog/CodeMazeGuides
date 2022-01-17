using ActionAndFunc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionAndFuncTests

{

    [TestClass]
    public class ActionAndFuncUnitTests
    {

        private const string _quote = "I am the one who knocks.";

        [TestMethod]
        public void GivenEmpty_ThenQuote()
        {

            string quote = Program.GetQuote();

            Assert.AreEqual(_quote, quote);

        }

        [TestMethod]
        public void GivenEven_ThenTrue()
        {

            bool result = Program.IsEven(2);

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void GivenOdd_ThenTrue()
        {

            bool result = Program.IsEven(3);

            Assert.AreEqual(false, result);

        }
    }
}