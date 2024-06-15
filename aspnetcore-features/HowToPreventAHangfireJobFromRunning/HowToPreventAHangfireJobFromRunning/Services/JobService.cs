namespace HowToPreventAHangfireJobFromRunning.Services;

public class JobService
{
    private const int TimeoutInSeconds = 9 * 60;
    private const int OperationDurationInSeconds = 10 * 60;
    
    private readonly ILogger<JobService> _logger;

    public JobService(ILogger<JobService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public async Task RunJob1Async() => await PerformLongRunningOperationAsync(nameof(RunJob1Async));

    [DisableConcurrentExecution(timeoutInSeconds: TimeoutInSeconds)]
    public async Task RunJob2Async() => await PerformLongRunningOperationAsync(nameof(RunJob2Async));

    [SkipConcurrentExecution]
    public async Task RunJob3Async() => await PerformLongRunningOperationAsync(nameof(RunJob3Async)); 
    
    private async Task PerformLongRunningOperationAsync(string jobName)
    {
        var guid = Guid.NewGuid();
        
        _logger.LogInformation("Starting job \"{JobName}\", operation: {Guid}", jobName, guid);
        
        await Task.Delay(TimeSpan.FromSeconds(OperationDurationInSeconds));
        
        _logger.LogInformation("Finished job \"{JobName}\" operation: {Guid}", jobName, guid);
    }
}