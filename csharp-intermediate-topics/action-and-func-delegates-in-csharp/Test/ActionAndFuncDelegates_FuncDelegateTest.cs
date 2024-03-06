using ActionAndFuncDelegates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test
{
    [TestClass]
    public class ActionAndFuncDelegates_FuncDelegateTest
    {
        private FuncDelegate _funcDelegate = new FuncDelegate();
        private string _helloWorldStr = "Hello, world!";
        private string _helloNameStr = $"Hello, Jack!";
        private string _helloEmptyNameStr = $"Hello, !";

        [TestMethod]
        public void Given_GetGreeting_Initialized_When_GetGreeting_Method_Called_Then_Returns_Correct_Greeting()
        {
            var helloWorldStr = _funcDelegate.GetGreeting();
            
            Assert.AreEqual(helloWorldStr, _helloWorldStr);
        }

        [TestMethod]
        public void Given_Name_When_Greet_Method_Called_Then_Returns_Correct_Greeting()
        {
            var name = "Jack";
            var helloNameStr = _funcDelegate.Greet(name);
            
            Assert.AreEqual(helloNameStr, _helloNameStr);
        }

        [TestMethod]
        public void GreetFunction_WhenCalledWithEmptyName_ReturnsExpectedGreeting()
        {
            var name = "";
            var helloNameStr = _funcDelegate.Greet(name);
            
            Assert.AreEqual(helloNameStr, _helloEmptyNameStr);
        }
        
        [TestMethod]
        public void When_Addition_Method_Called_With_Positive_Numbers()
        {
            var result = _funcDelegate.Add(7, 8);
            
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void When_Addition_Method_Called_With_Negative_Numbers()
        {
            var result = _funcDelegate.Add(-10, -7);
            
            Assert.AreEqual(-17, result);
        }

        [TestMethod]
        public void When_Addition_Method_Called_With_Zero()
        {
            var result = _funcDelegate.Add(0, 0);
            
            Assert.AreEqual(0, result);
        }
    }
}