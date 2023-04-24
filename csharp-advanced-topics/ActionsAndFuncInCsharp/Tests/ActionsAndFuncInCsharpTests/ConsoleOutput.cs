namespace ActionsAndFuncInCsharpTests;


internal class ConsoleOutput : IDisposable
{
    private readonly System.IO.StringWriter _stringWriter;
    private readonly System.IO.TextWriter _originalOutput;

    public ConsoleOutput()
    {
        _stringWriter = new System.IO.StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    public string GetOutput()
    {
        return _stringWriter.ToString();
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }
}