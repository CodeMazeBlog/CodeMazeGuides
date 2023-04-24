

using ActionAndFuncInCsharpConsole;

namespace ActionsAndFuncInCsharpTests;


    public class FuncExampleTests
    {
        [Fact]
        public void PerformCalculate_WithPlusOperation_ShouldReturnSum()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = 7;

            // Act
            funcExample.PerformCalculate('+', 3, 4);
            var consoleOutput = new ConsoleOutput();
            funcExample.DoSomeWork();
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.Contains(expectedResult.ToString(), output);
        }

        [Fact]
        public void PerformCalculate_WithCustomFunction_ShouldReturnFunctionResultPlusOne()
        {
            // Arrange
            var funcExample = new FuncExample();
            Func<int, int, int> customFunction = (a, b) => a * b;
            var expectedResult = 13;

            // Act
            funcExample.PerformCalculate(3, 4, customFunction);
            var consoleOutput = new ConsoleOutput();
            funcExample.DoSomeWork();
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.Contains(expectedResult.ToString(), output);
        }

        [Fact]
        public void PerformCalculate_WithSumFunction_ShouldReturnSum()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = "6";

            // Act
            var consoleOutput = new ConsoleOutput();
            funcExample.PerformCalculate(1, 4, funcExample.Sum);
          
           
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.Contains(expectedResult.ToString(), output);
        }

        [Fact]
        public void PerformCalculate_WithDifferenceFunction_ShouldReturnDifference()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = "3";

            // Act
            var consoleOutput = new ConsoleOutput();
            funcExample.PerformCalculate(4, 2, funcExample.Difference);
          
           
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.True(expectedResult.Contains(output));
        }

        [Fact]
        public void GetRandomNumber_ShouldReturnRandomNumber()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = true;

            // Act
            var randomNumber = funcExample.GetRandomNumber();
            var isInRange = randomNumber >= 1 && randomNumber <= 100;

            // Assert
            Assert.Equal(expectedResult, isInRange);
        }
    }
