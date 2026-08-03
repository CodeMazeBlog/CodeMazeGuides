namespace Quartz.NET;
public class BackgroundJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
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
