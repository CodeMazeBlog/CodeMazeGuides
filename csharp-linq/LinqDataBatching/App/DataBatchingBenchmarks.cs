using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace App;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class DataBatchingBenchmarks
{
    private const int BatchSize = 100;
    private readonly List<int> _data;

    public DataBatchingBenchmarks()
    {
        _data = new List<int>();
        for (var i = 0; i < 10000; i++) _data.Add(i);
    }

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