namespace HowToPreventAHangfireJobFromRunningWhenItIsAlreadyActive.Services;

public interface IService
{
    Task ProcessAsync();
}