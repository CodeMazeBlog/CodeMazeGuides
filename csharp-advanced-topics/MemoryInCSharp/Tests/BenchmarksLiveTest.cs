using App;
using BenchmarkDotNet.Reports;

namespace Tests;

public class BenchmarksLiveTest
{
    [Fact]
    public void GivenMemoryAndStandardArrayAreInitialized_WhenElementsAreModifiedInBothArrays_ThenMemoryArrayModificationPerformanceIsBetter()
    {
        var summary = MemoryVsArrayBenchmarks.RunBenchmarks();
        var standardArrayBenchmarkResult = GetBenchmarkResult(summary, nameof(MemoryVsArrayBenchmarks.ModifyStandardArrayElementsAsync));
        var memoryArrayBenchmarkResult = GetBenchmarkResult(summary, nameof(MemoryVsArrayBenchmarks.ModifyMemoryArrayElementsAsync));
        
        Assert.True(memoryArrayBenchmarkResult < standardArrayBenchmarkResult);
    }
   private static double GetBenchmarkResult(Summary summary, string benchmarkName)
    {
        return summary.Reports
            .First(r => r.BenchmarkCase.Descriptor.WorkloadMethod.Name == benchmarkName)
            .ResultStatistics!.Mean;
    }
}