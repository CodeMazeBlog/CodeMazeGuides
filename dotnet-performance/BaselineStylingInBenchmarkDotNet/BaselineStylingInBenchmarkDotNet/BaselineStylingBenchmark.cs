using BenchmarkDotNet.Attributes;

namespace BaselineStylingInBenchmarkDotNet;

[Config(typeof(StyleConfig))]
public class BaselineStylingBenchmark(int finalNumber = 2000)
{
    [Benchmark(Baseline = true)]
    public int UseForLoop()
    {
        var sum = 0;
        for (int i = 1; i <= finalNumber; i++)
        {
            sum += i;
        }

        return sum;
    }

    [Benchmark]
    public int UseWhileLoop()
    {
        var sum = 0;
        int i = 1;
        while (i <= finalNumber)
        {
            sum += i;
            i++;
        }

        return sum;
    }

    [Benchmark]
    public int UseEnumerableSum()
        => Enumerable.Range(1, finalNumber).Sum();
}