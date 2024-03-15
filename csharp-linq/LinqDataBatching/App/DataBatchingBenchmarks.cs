using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace App;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DataBatchingBenchmarks
{
    private const int BatchSize = 100;
    private readonly List<int> _data = Enumerable.Range(0, 10000).ToList();

    [Benchmark]
    public void BatchByTraditionalBenchmark()
    {
        _data.BatchByTraditional(BatchSize);
    }

    [Benchmark]
    public void BatchByLinqBenchmark()
    {
        _data.BatchByLinq(BatchSize);
    }

    [Benchmark]
    public void BatchByChunkBenchmark()
    {
        _data.BatchByChunk(BatchSize);
    }

    public static Summary RunBenchmarks()
    {
        return BenchmarkRunner.Run<DataBatchingBenchmarks>();
    }
}