using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CommunityToolkit.HighPerformance.Buffers;
using System.Text;

namespace HowToUseStringPoolBenchmark;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
public class HowtoUseStringPoolBenchmark
{
    private const int ChunkSize = 64;
    private char[] charArray;

    [Params(1000, 10000, 100000)]
    public int Iterations;

    [GlobalSetup]
    public void Setup()
    {
        charArray = new char[1024];
        Array.Fill(charArray, 'a');
    }

    [Benchmark(Description = "UseString")]
    public void Benchmark_UseString()
    {
        for (int i = 0; i < Iterations; i++)
        {
            int startIndex = i % (charArray.Length - ChunkSize);
            string instance = new(charArray, startIndex, ChunkSize);
        }
    }

    [Benchmark(Description = "UseStringPool")]
    public void Benchmark_UseStringPool()
    {
        for (int i = 0; i < Iterations; i++)
        {
            int startIndex = i % (charArray.Length - ChunkSize);
            ReadOnlySpan<char> span = charArray.AsSpan(startIndex, ChunkSize);
            var instance = StringPool.Shared.GetOrAdd(span);

        }
    }

    [Benchmark(Description = "UseStringBuilder")]
    public void Benchmark_UseStringBuilder()
    {
        for (int i = 0; i < Iterations; i++)
        {
            int startIndex = i % (charArray.Length - ChunkSize);
            var sb = new StringBuilder();
            sb.Append(charArray, startIndex, ChunkSize);
            string instance = sb.ToString();
            sb.Clear();
        }
    }
}
