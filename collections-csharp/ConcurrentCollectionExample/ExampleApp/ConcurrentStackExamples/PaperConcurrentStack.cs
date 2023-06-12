using System.Collections.Concurrent;

namespace ExampleApp.ConcurrentStackExamples;

public class PrinterColorPaperConcurrentStack
{
    private readonly ConcurrentStack<string> _paperColor;

    public PrinterColorPaperConcurrentStack()
    {
        _paperColor = new ConcurrentStack<string>();
    }

    public void Add(string color)
    {
        _paperColor.Push(color);
    }

    public bool TryUse(out string? color)
    {
        return _paperColor.TryPop(out color);
    }

    public bool TryGetTop(out string? color)
    {
        return _paperColor.TryPeek(out color);
    }    

    public int Count()
    {
        return _paperColor.Count();
    }
}