using ActionAndFuncDelegates;

namespace Test
{
    [TestClass]
    public class ActionAndFuncDelegates_ActionDelegateTest
    {
        private ActionDelegate _actionDelegate = new ActionDelegate();
        private string _helloWorldStr = "Hello, world!";
        private string _helloNameStr = $"Hello, Jack!";
       [TestMethod]
        public void GetGreetingTest()
        {
            _actionDelegate.PrintHello();
        }

        [TestMethod]
        public void GreetTest()
        {
            _actionDelegate.Greet("Jack");
        }
        [TestMethod]
        public void AAddTest()
        {
            _actionDelegate.Add(7,8);
        }
    }
}