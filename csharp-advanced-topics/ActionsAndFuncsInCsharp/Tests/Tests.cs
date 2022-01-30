using ActionsAndFuncsInCsharp.Examples;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly DelegateExample _delegateExample;
        private readonly ActionExample _actionExample;
        private readonly FuncExample _funcExample;

        public Tests()
        {
            _delegateExample = new DelegateExample();
            _actionExample = new ActionExample();
            _funcExample = new FuncExample();
        }

        [Fact]
        public void DelegateRunExample_WhenCalled_WritesToConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            _delegateExample.RunExample();

            // Assert
            Assert.Contains("Hello World", stringWriter.ToString());
        }

        [Fact]
        public void ActionRunExample_WhenCalled_WritesToConsole()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            _actionExample.RunExample();

            // Assert
            Assert.Contains("Hello World", stringWriter.ToString());
        }

        [Fact]
        public void FuncRunExample_WhenCalled_ReturnsAdditionOfInputs()
        {
            // Act
            var result = _funcExample.RunExample(1, 2);

            // Assert
            Assert.Equal(3, result);
        }
    }
}