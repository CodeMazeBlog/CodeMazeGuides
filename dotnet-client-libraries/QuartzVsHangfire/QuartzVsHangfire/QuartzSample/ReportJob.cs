using Quartz;
using QuartzVsHangfire.Services;

namespace QuartzVsHangfire.QuartzSample;

// A Quartz.NET job is a class implementing IJob. The scheduler resolves it from
// DI, so constructor-injected services (here IReportBuilder) just work.
public class ReportJob : IJob
{
    private readonly IReportBuilder _reportBuilder;

    public ReportJob(IReportBuilder reportBuilder) => _reportBuilder = reportBuilder;

    // 4.x signature: ValueTask plus the scheduler's CancellationToken.
    public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = default)
        => await _reportBuilder.RunAsync();
}
