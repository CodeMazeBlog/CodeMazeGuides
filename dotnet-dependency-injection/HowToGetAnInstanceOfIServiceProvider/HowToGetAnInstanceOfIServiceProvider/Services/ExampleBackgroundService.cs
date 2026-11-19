namespace HowToGetAnInstanceOfIServiceProvider.Services;

public class ExampleBackgroundService(IServiceProvider serviceProvider) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IExampleService>();

        return Task.CompletedTask;
    }
}