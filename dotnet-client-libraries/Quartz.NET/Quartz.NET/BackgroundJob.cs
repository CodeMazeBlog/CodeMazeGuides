namespace Quartz.NET;
public class BackgroundJob : IJob
{
    public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        var jobDataMap = context.MergedJobDataMap;

        var useJobDataMapConsoleOutput = jobDataMap.GetBoolean("UseJobDataMapConsoleOutput");

        if (useJobDataMapConsoleOutput)
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
