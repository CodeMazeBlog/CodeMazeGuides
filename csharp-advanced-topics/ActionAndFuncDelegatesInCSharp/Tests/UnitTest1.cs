using Xunit;
using System;

public class DelegatesTests
{
    private readonly Action action1 = () => Console.WriteLine("Action Without Parameters");
    private readonly Action<string, int> action2 = (a, b) => Console.WriteLine($"Action with parameters: {a} and int parameter {b}");
    private readonly Func<string> func1 = () => "Func Without Parameters";
    private readonly Func<string, int, string> func2 = (a, b) => $"{a} is {b} years Old";
    private readonly Func<int, int, int> func3 = (a, b) => a + b;
    [Fact]
    public void ActionWithoutParametersTest()
    {
        // Arrange
        string expectedOutput = "Action Without Parameters";
        var consoleWriter = new ConsoleWriter();

        // Act
        consoleWriter.ExecuteAction(() => action1());

        // Assert
        Assert.Equal(expectedOutput, consoleWriter.GetOutput());
    }

    [Fact]
    public void ActionWithParametersTest()
    {
        // Arrange
        string expectedOutput = "Action with parameters: string Parameter a and int parameter 1";
        var consoleWriter = new ConsoleWriter();

        // Act
        consoleWriter.ExecuteAction(() => action2("string Parameter a", 1));

        // Assert
        Assert.Equal(expectedOutput, consoleWriter.GetOutput());
    }

    [Fact]
    public void FuncWithoutParametersTest()
    {
        // Arrange
        string expectedOutput = "Func Without Parameters";

        // Act
        string result = func1();

        // Assert
        Assert.Equal(expectedOutput, result);
    }


    [Fact]
    public void FuncWithParametersTest()
    {
        // Arrange
        string expectedOutput = "Jane is 20 years Old";

        // Act
        string result = func2("Jane", 20);
       
        // Assert
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void FuncAdditionTest()
    {
        // Arrange
        int expectedOutput = 5;

        // Act
        int result = func3(2, 3);

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    // Helper class to capture Console output
    public class ConsoleWriter : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;

        public ConsoleWriter()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public void Dispose()
        {
            stringWriter.Dispose();
            Console.SetOut(originalOutput);
        }

        public string GetOutput()
        {
            return stringWriter.ToString().Trim();
        }

        public void ExecuteAction(Action action)
        {
            action();
        }
    }
    
}