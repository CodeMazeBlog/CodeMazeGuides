namespace HowToPreventAHangfireJobFromRunning.Services;

public class JobService : IJobService
{
    private const int TimeoutInSeconds = 9 * 60;
    private const int OperationDurationInSeconds = 10 * 60;
    
    private readonly ILogger<JobService> _logger;

    public JobService(ILogger<JobService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public void Job1()
    {
        PerformLongRunningOperation(nameof(Job1));
    }

    [DisableConcurrentExecution(timeoutInSeconds: TimeoutInSeconds)]
    public void Job2()
    {
        PerformLongRunningOperation(nameof(Job2));
    }

    public void Job3()
    {
        PerformLongRunningOperation(nameof(Job3));
    }
    
    private void PerformLongRunningOperation(string jobName)
    {
        var guid = Guid.NewGuid();
        
        _logger.LogInformation("Starting job \"{JobName}\", operation: {Guid}", jobName, guid);
        
        Thread.Sleep(TimeSpan.FromMinutes(OperationDurationInSeconds));
        
        _logger.LogInformation("Finished job \"{JobName}\" operation: {Guid}", jobName, guid);
    }
}