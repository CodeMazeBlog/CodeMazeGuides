namespace Tests;

public class StringConcatBenchmarkTest : IClassFixture<BenchmarkFixture>
{
    private readonly BenchmarkFixture _benchmarkFixture;

    public StringConcatBenchmarkTest(BenchmarkFixture benchmarkFixture)
    {
        _benchmarkFixture = benchmarkFixture;
    }

    [Fact]
    public void Given_When_BenchmarkTests_Are_Run_Then_Six_Cases_Must_Be_Executed()
    {
        var benchmarkCases = _benchmarkFixture.BenchmarkSummary.Reports.Select(x => x.BenchmarkCase).ToList();
        Assert.True(benchmarkCases.Count == 6, $"Case count was {benchmarkCases.Count}");
    }


    [Fact]
    public void Given_When_StringInterpolation_Case_Is_Executed_Then_It_ShouldNotTakeMoreThanTwentyFiveNanoSecs()
    {
        var stats = _benchmarkFixture.BenchmarkSummary.Reports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").ResultStatistics;
        Assert.True(stats is { Mean: < 25 }, $"Mean was {stats.Mean}");
    }

    [Fact]
    public void Given_When_StringInterpolation_Case_Is_Executed_Then_It_ShouldNotConsumeMemoryMoreThanMaxAllocation()
    {
        const int maxAllocation = 1342178216;
        var memoryStats = _benchmarkFixture.BenchmarkSummary.Reports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").GcStats;

        var stringInterpolationCase = _benchmarkFixture.BenchmarkSummary.Reports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").BenchmarkCase;
        var allocation = memoryStats.GetBytesAllocatedPerOperation(stringInterpolationCase);
        Assert.True(allocation <= maxAllocation, $"Allocation was {allocation}");

        Assert.True(memoryStats.GetTotalAllocatedBytes(true) is <= maxAllocation,
            $"TotalAllocatedBytes was {memoryStats.GetTotalAllocatedBytes(true)}");
    }

    [Fact]
    public void Given_When_StringInterpolation_Case_Is_Executed_Then_ZeroAllocationInGen1AndGen2()
    {
        var memoryStats = _benchmarkFixture.BenchmarkSummary.Reports.First(x =>
            x.BenchmarkCase.Descriptor.DisplayInfo == "StringConcatBenchmarks.StringInterpolation").GcStats;

        Assert.True(memoryStats.Gen1Collections == 0, $"Gen1Collections was {memoryStats.Gen1Collections}");
        Assert.True(memoryStats.Gen2Collections == 0, $"Gen2Collections was {memoryStats.Gen2Collections}");
    }
}