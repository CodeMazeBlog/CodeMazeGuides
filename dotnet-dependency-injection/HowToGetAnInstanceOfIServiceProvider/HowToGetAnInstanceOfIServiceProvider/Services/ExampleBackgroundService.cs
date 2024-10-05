namespace HowToGetAnInstanceOfIServiceProvider.Services;

public class ExampleBackgroundService(IServiceProvider ServiceProvider) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = ServiceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IExampleService>();

        return Task.CompletedTask;
    }
}