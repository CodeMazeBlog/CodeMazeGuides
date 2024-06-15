namespace HowToPreventAHangfireJobFromRunning.Services;

public class JobService : IJobService
{
    private const int SleepTimeInMilliseconds = 5000;
    
    private readonly ILogger<JobService> _logger;

    public JobService(ILogger<JobService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public void Job1()
    {
        PerformOperation();
    }

    public void Job2()
    {
        PerformOperation();
    }

    public void Job3()
    {
        PerformOperation();
    }
    
    private void PerformOperation()
    {
        var guid = Guid.NewGuid();
        
        _logger.LogInformation("Starting operation: {Guid}", guid);
        
        Thread.Sleep(SleepTimeInMilliseconds);
        
        _logger.LogInformation("Finished operation: {Guid}", guid);
    }
}