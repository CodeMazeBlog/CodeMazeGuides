using System.Collections;
using BenchmarkDotNet.Attributes;

namespace BoxingBench;

// Measures the one claim the article argues from mechanism: List is faster than ArrayList
// because it does not box, so the effect is large for value types and small for reference types.
// Both collections are created with the final capacity, so the only allocation difference left
// is the boxing itself.
[MemoryDiagnoser]
public class BoxingBenchmark
{
    private const int N = 1000;

    private static readonly string[] Words = CreateWords();

    private static string[] CreateWords()
    {
        var words = new string[N];
        for (var i = 0; i < N; i++)
        {
            words[i] = "item-" + i;
        }

        return words;
    }

    [Benchmark(Description = "ArrayList, 1000 int")]
    public int ArrayListOfInt()
    {
        var collection = new ArrayList(N);
        for (var i = 0; i < N; i++)
        {
            collection.Add(i);
        }

        var sum = 0;
        foreach (var item in collection)
        {
            sum += (int)item!;
        }

        return sum;
    }

    [Benchmark(Description = "List, 1000 int")]
    public int ListOfInt()
    {
        var collection = new List<int>(N);
        for (var i = 0; i < N; i++)
        {
            collection.Add(i);
        }

        var sum = 0;
        foreach (var item in collection)
        {
            sum += item;
        }

        return sum;
    }

    [Benchmark(Description = "ArrayList, 1000 string")]
    public int ArrayListOfString()
    {
        var collection = new ArrayList(N);
        for (var i = 0; i < N; i++)
        {
            collection.Add(Words[i]);
        }

        var total = 0;
        foreach (var item in collection)
        {
            total += ((string)item!).Length;
        }

        return total;
    }

    [Benchmark(Description = "List, 1000 string")]
    public int ListOfString()
    {
        var collection = new List<string>(N);
        for (var i = 0; i < N; i++)
        {
            collection.Add(Words[i]);
        }

        var total = 0;
        foreach (var item in collection)
        {
            total += item.Length;
        }

        return total;
    }
}
