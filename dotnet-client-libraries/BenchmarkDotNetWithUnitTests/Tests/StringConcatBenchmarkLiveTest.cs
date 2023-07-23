using System.Collections.Immutable;
using BenchmarkDotNet.Reports;

namespace Tests;

public class StringConcatBenchmarkLiveTest : IClassFixture<BenchmarkFixture>
{
    private readonly ImmutableArray<BenchmarkReport> _benchmarkReports;
    private readonly BenchmarkReport _stringInterpolationReport;

    public StringConcatBenchmarkLiveTest(BenchmarkFixture benchmarkFixture)
    {
        _benchmarkReports = benchmarkFixture.BenchmarkSummary.Reports;
        _stringInterpolationReport = _benchmarkReports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation");
    }

    [Fact]
    public void WhenBenchmarkTestsAreRun_ThenFourCasesMustBeExecuted()
    {
        var benchmarkCases = _benchmarkReports.Length;
        
        Assert.Equal(4, benchmarkCases);
    }

    [Fact]
    public void WhenStringInterpolationCaseIsExecuted_ThenItShouldNotTakeMoreThanFifteenNanoSecs()
    {
        var stats = _stringInterpolationReport.ResultStatistics;
        
        Assert.True(stats is { Mean: < 15 }, $"Mean was {stats.Mean}");
    }

    [Fact]
    public void WhenStringInterpolationCaseIsExecuted_ThenItShouldNotConsumeMemoryMoreThanMaxAllocation()
    {
        const int maxAllocation = 1342178216;
        var memoryStats = _stringInterpolationReport.GcStats;
        var stringInterpolationCase = _stringInterpolationReport.BenchmarkCase;
        var allocation = memoryStats.GetBytesAllocatedPerOperation(stringInterpolationCase);
        var totalAllocatedBytes = memoryStats.GetTotalAllocatedBytes(true);
        
        Assert.True(allocation <= maxAllocation, $"Allocation was {allocation}");
        Assert.True(totalAllocatedBytes <= maxAllocation,
            $"TotalAllocatedBytes was {totalAllocatedBytes}");
    }

    [Fact]
    public void WhenStringInterpolationCaseIsExecuted_ThenZeroAllocationInGen1AndGen2()
    {
        var memoryStats = _stringInterpolationReport.GcStats;
        
        Assert.True(memoryStats.Gen1Collections == 0, $"Gen1Collections was {memoryStats.Gen1Collections}");
        Assert.True(memoryStats.Gen2Collections == 0, $"Gen2Collections was {memoryStats.Gen2Collections}");
    }
}