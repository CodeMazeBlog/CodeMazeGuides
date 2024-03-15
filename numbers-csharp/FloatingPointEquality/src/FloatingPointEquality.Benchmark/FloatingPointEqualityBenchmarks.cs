using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using FloatingPointEquality.Library;

namespace FloatingPointEquality.Benchmark;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class FloatingPointEqualityBenchmarks
{
    private record Values(double A, double B, int Precision, double Tolerance, long MaxUlps);

    private const int ValuesCount = 1000;
    private Values[] _values = Array.Empty<Values>();

    private static double IncrementBits(double value, int numberOfIncrements)
    {
        for (var i = 0; i < numberOfIncrements; ++i) value = double.BitIncrement(value);

        return value;
    }

    [GlobalSetup]
    public void GlobalSetup()
    {
        const int bitIncrements = 15;
        var rand = new Random(42);
        _values = new Values[ValuesCount];
        for (var i = 0; i < ValuesCount; ++i)
        {
            var a = rand.NextDouble() * rand.Next(5, 500);
            var b = IncrementBits(a, bitIncrements);
            _values[i] = new Values(a, b, 5, 1e-5, bitIncrements - 2);
        }
    }

    [Benchmark]
    public int CheckEqualityUsingPrecision()
    {
        var equalCount = 0;
        foreach (var (a, b, precision, _, _) in _values)
            if (FloatingPointComparisons.EqualityUsingPrecision(a, b, precision))
                ++equalCount;

        return equalCount;
    }

    [Benchmark]
    public int CheckEqualityUsingTolerance()
    {
        var equalCount = 0;
        foreach (var (a, b, _, tolerance, _) in _values)
            if (FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance))
                ++equalCount;

        return equalCount;
    }

    [Benchmark]
    public int CheckEqualityUsingMaxUnitsInLastPlace()
    {
        var equalCount = 0;
        foreach (var (a, b, _, _, maxUlps) in _values)
            if (FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlps))
                ++equalCount;

        return equalCount;
    }
}