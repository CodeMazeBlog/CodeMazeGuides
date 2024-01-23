using App;
using BenchmarkDotNet.Reports;

namespace Tests;

public class DataBatchingBenchmarkLiveTest
{
    [Fact]
    public void GivenListOfIntegers_WhenComparingBatchingApproaches_ThenChunkIsFastest()
    {
        var summary = DataBatchingBenchmarks.RunBenchmarks();

        var traditionalBenchmark = GetBenchmarkResult(summary, nameof(DataBatchingBenchmarks.BatchByTraditionalBenchmark));
        var linqBenchmark = GetBenchmarkResult(summary, nameof(DataBatchingBenchmarks.BatchByLinqBenchmark));
        var chunkBenchmark = GetBenchmarkResult(summary, nameof(DataBatchingBenchmarks.BatchByChunkBenchmark));

        Assert.True(chunkBenchmark < traditionalBenchmark);
        Assert.True(chunkBenchmark < linqBenchmark);
    }

    private static double GetBenchmarkResult(Summary summary, string benchmarkName)
    {
        return summary.Reports
            .First(r => r.BenchmarkCase.Descriptor.WorkloadMethod.Name == benchmarkName)
            .ResultStatistics!.Mean;
    }
}