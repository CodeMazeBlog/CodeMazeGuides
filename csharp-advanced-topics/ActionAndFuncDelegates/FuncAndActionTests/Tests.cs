using FuncAndAction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests : IDisposable
    {
        StringWriter sw;

        public Tests()
        {
            sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);
        }

        public void Dispose()
        {
            sw.Dispose();
            Console.SetOut(Console.Out);
            Console.SetError(Console.Error);
        }

        [TestMethod]
        public void GivenSimpleDelegateInstance_WhenRunIsCalled_ThenOutputIsCorrect()
        {
            new DelegateExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();

            Assert.AreEqual("12345", result);
        }

        [TestMethod]
        public void GivenMulticastDelegate_WhenRunIsCalled_ThenOutputIsCorrect()
        {
            new MulticastDelegateExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();

            Assert.AreEqual("11012102310341045105", result);
        }

        [TestMethod]
        public void GivenActionDelegate_WhenRunIsCalled_ThenOutputIsCorrect()
        {
            new ActionExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();

            Assert.AreEqual("12345", result);
        }

        [TestMethod]
        public void GivenFuncDelegate_WhenRunIsCalled_ThenOutputIsCorrect()
        {
            new FuncExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();

            Assert.AreEqual("12345Hello World", result);
        }

        [TestMethod]
        public void GivenListWithActionDelegate_WhenRunIsCalled_ThenOutputIsCorrect()
        {
            new ListWithActionExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();

            Assert.AreEqual("12345", result);
        }
    }
}
