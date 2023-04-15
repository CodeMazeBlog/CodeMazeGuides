using ActionAndFuncDelegatesInCSharp;
using System.Text;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void GivenTwoNumbers_WhenFuncIsCalled_ThenReturnProduct()
        {
            var calculator = new Calculator();
            var addFunc = new Func<int, int, int>(calculator.Multiply);
            var result = addFunc.Invoke(4, 5);

            Assert.Equal(20, result);
        }

        [Fact]
        public void Log_ShouldCallCallbackWithCorrectMessage()
        {
            var logger = new Logger();
            var message = "Hello, world!";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            logger.Log(message);

            Assert.Equal($"Log: {message}", consoleOutput.ToString().Trim());
        }
    }
}