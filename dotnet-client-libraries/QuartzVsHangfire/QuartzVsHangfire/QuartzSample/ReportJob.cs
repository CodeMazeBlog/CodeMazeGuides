using Quartz;
using QuartzVsHangfire.Services;

namespace QuartzVsHangfire.QuartzSample;

// A Quartz.NET job is a class implementing IJob. The scheduler resolves it from
// DI, so constructor-injected services (here IReportBuilder) just work.
public class ReportJob : IJob
{
    private readonly IReportBuilder _reportBuilder;

    public ReportJob(IReportBuilder reportBuilder) => _reportBuilder = reportBuilder;

    public Task Execute(IJobExecutionContext context) => _reportBuilder.RunAsync();
}
