using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Test
{
    [TestClass]
    public class ActionAndFuncDelegates_ActionDelegateTest
    {
        private ActionDelegate _actionDelegate = new ActionDelegate();
        private string _helloWorldStr = "Hello, world!";
        private string _helloNameStr = $"Hello, Jack!";
        
        [TestMethod]
        public void Given_PrintHello_Action_When_PrintHello_Called_Then_PrintsHelloWorld()
        {
            _actionDelegate.PrintHello.Invoke();
            using (var consoleOutput = new ConsoleOutput())
            {
                _actionDelegate.PrintHello.Invoke();
                Assert.AreEqual("Hello, world!" + Environment.NewLine, consoleOutput.GetOutput());
            }
        }

        [TestMethod]
        public void Given_GreetAction_When_InvokeWithName_Then_PrintsCorrectGreeting()
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                _actionDelegate.Greet("Alice");
                Assert.AreEqual("Hello, Alice!" + Environment.NewLine, consoleOutput.GetOutput());
            }
        }

        [TestMethod]
        public void Given_Two_Numbers_When_Add_Method_Called_Then_Prints_Correct_Sum()
        {
            int a = 5;
            int b = 10;
            int expectedSum = a + b;
            _actionDelegate.Add(a, b);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _actionDelegate.Add(a, b);
                string expectedOutput = $"Sum: {expectedSum}{Environment.NewLine}";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}