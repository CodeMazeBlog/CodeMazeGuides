namespace ReportApi.Tests;

public class ReportBuilderTests
{
    [Fact]
    public void WhenBuiltBothWays_ThenReportsAreEqual()
    {
        var concatenated = ReportBuilder.BuildWithConcatenation(100);
        var built = ReportBuilder.BuildWithStringBuilder(100);

        Assert.Equal(concatenated, built);
    }

    [Fact]
    public void WhenBuilt_ThenReportHasOneLinePerOrder()
    {
        var report = ReportBuilder.BuildWithStringBuilder(100);

        var lines = report.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal(100, lines.Length);
        Assert.Equal("Order 1: 2 items", lines[0]);
    }
}
