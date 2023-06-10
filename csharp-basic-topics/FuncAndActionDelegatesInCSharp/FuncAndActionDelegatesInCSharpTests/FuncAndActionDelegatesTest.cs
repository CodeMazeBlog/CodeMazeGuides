using FuncAndActionDelegatesInCSharp;

namespace FuncAndActionDelegatesInCSharpTests;

[TestFixture]
public class FuncAndActionDelegatesUnitTest
{
    [Test]
    public void WhenInvokingADelegate_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Delegates.Delegate();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenInvokingAnActionDelegate_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            ActionDelegates.ActionDelegate();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenInvokingActionDelegateWithMultipleParameters_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            ActionDelegates.ActionDelegateMultipleParameters();

            // Assert
            string expectedOutput = $"Hello, Code Maze @ {DateTime.Now:dd/MM/yyyy HH:mm}" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenInvokingFuncDelegates_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            FuncDelegates.FuncDelegate();

            // Assert
            string expectedOutput = $"Hello, Code Maze @ {DateTime.Now:dd/MM/yyyy HH:mm}" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenInvokingLambdaExpressions_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            LambdaExpressions.LambdaExpression();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenPassingLambdaExpressionsAsArguments_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            LambdaExpressions.LambdaExpressionsAsParameters();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenPerformingDelegatesDataTransformation_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            DelegateUseCases.DelegatesDataTransformation();

            // Assert
            string expectedOutput = "CODE MAZE" + Environment.NewLine + "C#" + Environment.NewLine + "DELEGATES" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenPerformingDelegatesConditionalFiltering_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            DelegateUseCases.DelegatesConditionalFiltering();

            // Assert
            string expectedOutput = "this string contains Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void WhenUsingDelegatesCallback_ThenItWritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            DelegateUseCases.DelegatesCallback();

            // Assert
            string expectedOutput = "Callback invoked with value: Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
