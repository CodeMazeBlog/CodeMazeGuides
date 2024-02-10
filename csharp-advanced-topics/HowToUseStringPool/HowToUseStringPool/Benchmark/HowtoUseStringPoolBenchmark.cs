using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CommunityToolkit.HighPerformance.Buffers;
using System.Text;

namespace HowToUseStringPool.Benchmark;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
public class HowtoUseStringPoolBenchmark
{
    private const int ChunkSize = 64;
    private char[] _charArray = null!;

    [Params(1000, 10000, 100000)]
    public int Iterations;

    [GlobalSetup]
    public void Setup()
    {
        _charArray = new char[1024];
        Array.Fill(_charArray, 'a');
    }

    [Benchmark(Description = "UseString")]
    public void Benchmark_UseString()
    {
        for (int i = 0; i < Iterations; i++)
        {
            int startIndex = i % (_charArray.Length - ChunkSize);

            var instance = new string(_charArray, startIndex, ChunkSize);
        }
    }

    [Benchmark(Description = "UseStringPool")]
    public void Benchmark_UseStringPool()
    {
        for (int i = 0; i < Iterations; i++)
        {
            int startIndex = i % (_charArray.Length - ChunkSize);
            ReadOnlySpan<char> span = _charArray.AsSpan(startIndex, ChunkSize);

            var instance = StringPool.Shared.GetOrAdd(span);
        }
    }

    [Benchmark(Description = "UseStringBuilder")]
    public void Benchmark_UseStringBuilder()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Iterations; i++)
        {
            int startIndex = i % (_charArray.Length - ChunkSize);
            sb.Append(_charArray, startIndex, ChunkSize);

            var instance = sb.ToString();
            sb.Clear();
        }
    }
}
