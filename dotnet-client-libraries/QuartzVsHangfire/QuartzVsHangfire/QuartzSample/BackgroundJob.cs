using Quartz;

namespace QuartzVsHangfire.QuartzSample;

public class BackgroundJob : IJob
{
    // Quartz.NET 4.x: Execute returns ValueTask and takes a CancellationToken.
    public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        var jobDataMap = context.MergedJobDataMap;

        // 4.x: GetBoolean throws InvalidCastException for a missing key, so an
        // optional entry is read with TryGetBoolean.
        if (jobDataMap.TryGetBoolean("UseJobDataMapConsoleOutput", out var useJobDataMapConsoleOutput)
            && useJobDataMapConsoleOutput)
        {
            var consoleOutput = jobDataMap.GetString("ConsoleOutput");
            await Console.Out.WriteLineAsync(consoleOutput);
        }
        else
        {
            await Console.Out.WriteLineAsync("Executing background job without JobDataMap");
        }
    }
}
