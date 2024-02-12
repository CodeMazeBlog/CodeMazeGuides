using ActionAndFuncDelegate.Action;
using ActionAndFuncDelegate.Func;
using System.Text;

namespace ActionAndFuncDelegate.Test
{
    public class ActionAndFuncTest : IDisposable
    {
        private readonly StringWriter _consoleOutput;
        private readonly TextWriter _originalConsoleOutput;

        public ActionAndFuncTest()
        {
            _consoleOutput = new StringWriter();
            _originalConsoleOutput = Console.Out;
            Console.SetOut(_consoleOutput);
        }

        public void Dispose()
        {
            Console.SetOut(_originalConsoleOutput);
            _consoleOutput.Dispose();
        }

        [Fact]
        public void WhenParameterIs10_ThenTheValueShouldBeMessageWith10()
        {
            // Arrange
            var expectedOutput = "The article number is: 10" + Environment.NewLine;
            var consoleOutput = new StringBuilder();
            var stringWriter = new StringWriter(consoleOutput);
            Console.SetOut(stringWriter);

            // Act
            ActionDelegateExample.ActionDelegate();
            var actualOutput = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }


        [Fact]
        public void WhenValuesAre3And5_ThenOutPutIs8()
        {
            // Arrange
            var expectedSum = 8;
            var consoleOutput = new StringBuilder();
            var stringWriter = new StringWriter(consoleOutput);
            Console.SetOut(stringWriter);

            // Act
            FuncDelegateExample.FuncDelegate();
            var actualOutput = consoleOutput.ToString();

            // Assert
            Assert.Contains("The result of adding 5 and 3 is: " + expectedSum, actualOutput);
        }
    }
}