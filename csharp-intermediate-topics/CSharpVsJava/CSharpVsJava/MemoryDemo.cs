namespace CSharpVsJava;

public static class MemoryDemo
{
    public static void Run()
    {
        const int count = 1_000_000;
        var before = GC.GetAllocatedBytesForCurrentThread();

        var quantities = new List<int>(count);
        for (var i = 0; i < count; i++)
        {
            quantities.Add(i);
        }

        var allocated = GC.GetAllocatedBytesForCurrentThread() - before;
        Console.WriteLine($"List<int> with {quantities.Count:N0} items: {allocated / 1_000_000.0:F1} MB allocated");
    }
}
