namespace HowToPreventAHangfireJobFromRunning.Services;

public interface IJobService
{
    [DisableConcurrentExecution(timeoutInSeconds: 0)]
    [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Delete)]
    Task RunJob1Async();

    [SkipConcurrentExecution]
    Task RunJob2Async();
}