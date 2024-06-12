namespace HowToPreventAHangfireJobFromRunningWhenItIsAlreadyActive.Services;

public interface IILongRunningService
{
    Task ProcessAsync();
}