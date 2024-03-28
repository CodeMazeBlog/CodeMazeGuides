using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BaselineStylingInBenchmarkDotNet;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class BaselineStylingBenchmark()
{
    private static readonly int _number = 2000;

    [Benchmark(Baseline = true)]
    public int UseForLoop()
    {
        var sum = 0;
        for (int i = 1; i <= _number; i++)
        {
            sum += i;
        }

        return sum;
    }

    public int UseEnumerableSum()
        => Enumerable.Range(1, _number).Sum();

    [Benchmark]
    public int UseWhileLoop()
    {
        var sum = 0;
        int i = 1;
        while (i <= _number)
        {
            sum += i;
            i++;
        }

        return sum;
    }
}