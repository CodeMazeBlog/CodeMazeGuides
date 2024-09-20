namespace HowToPreventAHangfireJobFromRunning.Services;

public class JobService
{
    private const int OperationDurationInSeconds = 10 * 60;

    private readonly ILogger<JobService> _logger;

    public JobService(ILogger<JobService> logger)
    {
        _logger = logger;
    }

    [DisableConcurrentExecution(timeoutInSeconds: 60)]
    public async Task RunJob1Async() => await PerformLongRunningOperationAsync(nameof(RunJob1Async));

    [SkipConcurrentExecution]
    public async Task RunJob2Async() => await PerformLongRunningOperationAsync(nameof(RunJob2Async));

    private async Task PerformLongRunningOperationAsync(string jobName)
    {
        var guid = Guid.NewGuid();

        _logger.LogInformation("Starting job \"{JobName}\", operation: {Guid}", jobName, guid);

        await Task.Delay(TimeSpan.FromSeconds(OperationDurationInSeconds));

        _logger.LogInformation("Finished job \"{JobName}\" operation: {Guid}", jobName, guid);
    }
}