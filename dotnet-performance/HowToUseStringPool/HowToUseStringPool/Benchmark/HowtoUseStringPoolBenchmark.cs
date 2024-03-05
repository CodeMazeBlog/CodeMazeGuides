using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using CommunityToolkit.HighPerformance.Buffers;

namespace HowToUseStringPool.Benchmark;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MemoryDiagnoser]
public class HowtoUseStringPoolBenchmark
{
    private const int ChunkSize = 64;
    private char[] _charArray = null!;

    private List<string> _dest = null!;

    [Params(1000, 10000, 100000)] public int Iterations;

    [GlobalSetup]
    public void GlobalSetup()
    {
        const int arraySize = 1024;
        ReadOnlySpan<char> chars = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p'];
        var groupLength = arraySize / chars.Length;

        _charArray = new char[arraySize];

        var span = _charArray.AsSpan();
        foreach (var c in chars)
        {
            span[..groupLength].Fill(c);
            span = span[groupLength..];
        }

        span.Fill('z');

        _dest = new List<string>(Iterations);
    }


    [Benchmark]
    public IList<string> UseString()
    {
        _dest.Clear();
        var startIndex = 0;
        for (var i = 0; i < Iterations; i++)
        {
            if (startIndex + ChunkSize > _charArray.Length)
            {
                startIndex = 0;
            }

            _dest.Add(new string(_charArray, startIndex, ChunkSize));

            startIndex += ChunkSize;
        }

        return _dest;
    }

    [Benchmark]
    public IList<string> UseStringPool()
    {
        _dest.Clear();
        var startIndex = 0;
        for (var i = 0; i < Iterations; i++)
        {
            if (startIndex + ChunkSize > _charArray.Length)
            {
                startIndex = 0;
            }

            ReadOnlySpan<char> span = _charArray.AsSpan(startIndex, ChunkSize);
            _dest.Add(StringPool.Shared.GetOrAdd(span));

            startIndex += ChunkSize;
        }

        return _dest;
    }

    [Benchmark]
    public IList<string> UseStringBuilder()
    {
        _dest.Clear();
        var sb = new StringBuilder();

        var startIndex = 0;
        for (var i = 0; i < Iterations; i++)
        {
            if (startIndex + ChunkSize > _charArray.Length)
            {
                startIndex = 0;
            }

            sb.Append(_charArray.AsSpan(startIndex, ChunkSize));

            _dest.Add(sb.ToString());

            sb.Clear();
            startIndex += ChunkSize;
        }

        return _dest;
    }
}