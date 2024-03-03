using ActionAndFuncDelegates;

namespace Test
{
    [TestClass]
    public class ActionAndFuncDelegates_FuncDelegateTest
    {
        private FuncDelegate _funcDelegate = new FuncDelegate();
        private string _helloWorldStr = "Hello, world!";
        private string _helloNameStr = $"Hello, Jack!";
       [TestMethod]
        public void GetGreetingTest()
        {
            string helloWorldStr = _funcDelegate.GetGreeting();
            Assert.AreEqual(helloWorldStr, _helloWorldStr);
        }

        [TestMethod]
        public void GreetTest()
        {
            string helloNameStr = _funcDelegate.Greet("Jack");
            Assert.AreEqual(helloNameStr, _helloNameStr);
        }
        [TestMethod]
        public void AAddTest()
        {
            int number = _funcDelegate.Add(7,8);
            Assert.AreEqual(number, 15);
        }
    }
}