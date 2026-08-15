namespace QuartzVsHangfire.Services;

public class ReportBuilder : IReportBuilder
{
    public Task RunAsync()
    {
        Console.WriteLine("Building the nightly report.");

        return Task.CompletedTask;
    }
}
