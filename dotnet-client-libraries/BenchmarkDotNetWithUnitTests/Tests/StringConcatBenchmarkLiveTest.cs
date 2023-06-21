using System.Collections.Immutable;
using BenchmarkDotNet.Reports;

namespace Tests;

public class StringConcatBenchmarkLiveTest : IClassFixture<BenchmarkFixture>
{
    private readonly ImmutableArray<BenchmarkReport> _benchmarkReports;

    public StringConcatBenchmarkLiveTest(BenchmarkFixture benchmarkFixture)
    {
        _benchmarkReports = benchmarkFixture.BenchmarkSummary.Reports;
    }

    [Fact]
    public void Given_When_BenchmarkTests_Are_Run_Then_Four_Cases_Must_Be_Executed()
    {
        var benchmarkCases = _benchmarkReports.Length;
        Assert.Equal(4, benchmarkCases);
    }


    [Fact]
    public void Given_When_StringInterpolation_Case_Is_Executed_Then_It_ShouldNotTakeMoreThanFifteenNanoSecs()
    {
        var stats = _benchmarkReports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").ResultStatistics;
        Assert.True(stats is { Mean: < 15 }, $"Mean was {stats.Mean}");
    }

    [Fact]
    public void Given_When_StringInterpolation_Case_Is_Executed_Then_It_ShouldNotConsumeMemoryMoreThanMaxAllocation()
    {
        const int maxAllocation = 1342178216;
        var memoryStats = _benchmarkReports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").GcStats;

        var stringInterpolationCase = _benchmarkReports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").BenchmarkCase;
        var allocation = memoryStats.GetBytesAllocatedPerOperation(stringInterpolationCase);
        Assert.True(allocation <= maxAllocation, $"Allocation was {allocation}");

        Assert.True(memoryStats.GetTotalAllocatedBytes(true) is <= maxAllocation,
            $"TotalAllocatedBytes was {memoryStats.GetTotalAllocatedBytes(true)}");
    }

    [Fact]
    public void Given_When_StringInterpolation_Case_Is_Executed_Then_ZeroAllocationInGen1AndGen2()
    {
        var memoryStats = _benchmarkReports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").GcStats;

        Assert.True(memoryStats.Gen1Collections == 0, $"Gen1Collections was {memoryStats.Gen1Collections}");
        Assert.True(memoryStats.Gen2Collections == 0, $"Gen2Collections was {memoryStats.Gen2Collections}");
    }
}