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
    
    public Task Job1() => PerformLongRunningOperation(nameof(Job1));

    [DisableConcurrentExecution(timeoutInSeconds: TimeoutInSeconds)]
    public Task Job2() => PerformLongRunningOperation(nameof(Job2));

    [DisableQueueing]
    public Task Job3() => PerformLongRunningOperation(nameof(Job3)); 
    
    private Task PerformLongRunningOperation(string jobName)
    {
        var guid = Guid.NewGuid();
        
        _logger.LogInformation("Starting job \"{JobName}\", operation: {Guid}", jobName, guid);
        
        Thread.Sleep(TimeSpan.FromMinutes(OperationDurationInSeconds));
        
        _logger.LogInformation("Finished job \"{JobName}\" operation: {Guid}", jobName, guid);
        
        return Task.CompletedTask;
    }
}