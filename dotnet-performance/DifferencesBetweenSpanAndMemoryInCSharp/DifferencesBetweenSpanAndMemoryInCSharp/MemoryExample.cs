namespace DifferencesBetweenSpanAndMemoryInCSharp;

public static class MemoryExample
{
    public static void IntArrayAsMemory()
    {
        int[] array = [1, 2, 3, 4, 5];

        var memory = array.AsMemory();

        Task.Run(() => ProcessArrayAsync(memory, 2)).Wait();
    }

    private static async Task ProcessArrayAsync(Memory<int> buffer, int length)
    {
        await Task.Delay(1000);
        Print(buffer.Span[..length]);
    }

    private static void Print(Span<int> span)
    {
        foreach (var element in span)
        {
            Console.WriteLine(element);
        }
    }
}
