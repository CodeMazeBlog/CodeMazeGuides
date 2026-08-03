using System.Collections.Immutable;
using BenchmarkDotNet.Reports;

namespace Tests;

public class UTF8LiveTest : IClassFixture<BenchmarkFixture>
{
    private readonly ImmutableArray<BenchmarkReport> _benchmarkReports;

    public UTF8LiveTest(BenchmarkFixture benchmarkFixture)
    {
        _benchmarkReports = benchmarkFixture.BenchmarkSummary.Reports;
    }

    [Fact]
    public void WhenBenchmarkAreRun_ThenNewSyntaxIsMorePerformantThanOldSyntax()
    {
        var oldSyntaxReport = _benchmarkReports.FirstOrDefault(report =>
            report.BenchmarkCase.Descriptor.WorkloadMethodDisplayInfo.Contains("OldSyntax"));
        var newSyntaxReport = _benchmarkReports.FirstOrDefault(report =>
            report.BenchmarkCase.Descriptor.WorkloadMethodDisplayInfo.Contains("NewSyntax"));

        var oldSyntaxStatistics = oldSyntaxReport!.ResultStatistics;
        var newSyntaxStatistics = newSyntaxReport!.ResultStatistics;

        var memoryGenAllocatedOldSyntax = oldSyntaxReport.GcStats.Gen0Collections +
                                          oldSyntaxReport.GcStats.Gen1Collections +
                                          oldSyntaxReport.GcStats.Gen2Collections;
        var memoryGenAllocatedNewSyntax = newSyntaxReport.GcStats.Gen0Collections +
                                          newSyntaxReport.GcStats.Gen1Collections +
                                          newSyntaxReport.GcStats.Gen2Collections;

        var memoryAllocatedOldSyntax = oldSyntaxReport.GcStats.GetTotalAllocatedBytes(true);
        var memoryAllocatedNewSyntax = newSyntaxReport.GcStats.GetTotalAllocatedBytes(true);
        
        Assert.True(newSyntaxStatistics!.Mean < oldSyntaxStatistics!.Mean);
        Assert.True(memoryAllocatedNewSyntax < memoryAllocatedOldSyntax);
        Assert.True(memoryGenAllocatedNewSyntax < memoryGenAllocatedOldSyntax);
    }
}