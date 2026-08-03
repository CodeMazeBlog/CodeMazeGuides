namespace InterceptorsInCSharp.Tests;

public sealed class ConsoleOutputTester : IDisposable
{
    private readonly StringWriter _consoleOutput = new();
    private readonly TextWriter _originalOutput;

    public ConsoleOutputTester()
    {
        _originalOutput = Console.Out;
        Console.SetOut(_consoleOutput);
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _consoleOutput.Dispose();
    }

    public string GetOutput() => _consoleOutput.ToString();
}
