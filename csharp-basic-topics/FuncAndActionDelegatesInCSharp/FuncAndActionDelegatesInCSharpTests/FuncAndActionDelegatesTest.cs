using FuncAndActionDelegatesInCSharp;
using NUnit.Framework;
using System;
using System.IO;

public class ConsoleOutputTester : IDisposable
{
    private StringWriter consoleOutput;
    private TextWriter originalOutput;

    public ConsoleOutputTester()
    {
        consoleOutput = new StringWriter();
        originalOutput = Console.Out;
        Console.SetOut(consoleOutput);
    }

    public void Dispose()
    {
        Console.SetOut(originalOutput);
        consoleOutput.Dispose();
    }

    public string GetOutput()
    {
        return consoleOutput.ToString();
    }
}

[TestFixture]
public class ProgramTests
{
    [Test]
    public void Delegate_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.Delegate();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void ActionDelegate_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.ActionDelegate();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void ActionDelegateMultipleParameters_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.ActionDelegateMultipleParameters();

            // Assert
            string expectedOutput = $"Hello, Code Maze @ {DateTime.Now:dd/MM/yyyy HH:mm}" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void FuncDelegates_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.FuncDelegates();

            // Assert
            string expectedOutput = $"Hello, Code Maze @ {DateTime.Now:dd/MM/yyyy HH:mm}" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void LambdaExpressions_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.LambdaExpressions();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void LambdaExpressionsAsParameters_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.LambdaExpressionsAsParameters();

            // Assert
            string expectedOutput = "Hello, Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void DelegatesDataTransformation_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.DelegatesDataTransformation();

            // Assert
            string expectedOutput = "CODE MAZE" + Environment.NewLine + "C#" + Environment.NewLine + "DELEGATES" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void DelegatesConditionalFiltering_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.DelegatesConditionalFiltering();

            // Assert
            string expectedOutput = "this string contains Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }

    [Test]
    public void DelegatesCallback_WritesCorrectConsoleOutput()
    {
        // Arrange
        using (var consoleOutputTester = new ConsoleOutputTester())
        {
            // Act
            Program.DelegatesCallback();

            // Assert
            string expectedOutput = "Callback invoked with value: Code Maze" + Environment.NewLine;
            string actualOutput = consoleOutputTester.GetOutput();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
