using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Test
{
    [TestClass]
    public class ActionAndFuncDelegates_ActionDelegateTest
    {
        private ActionDelegate _actionDelegate = new ActionDelegate();

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
            var a = 5;
            var b = 10;
            var expectedSum = a + b;
            _actionDelegate.Add(a, b);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _actionDelegate.Add(a, b);
                var expectedOutput = $"Sum: {expectedSum}{Environment.NewLine}";
                
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}