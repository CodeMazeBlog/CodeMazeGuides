using Microsoft.Extensions.Logging;
using NSubstitute;
using TheIHostedLifecycleServiceInterface.Services;

namespace Tests;

[TestClass]
public class HostedServiceBTests
{
    [TestMethod]
    public async Task GivenHostedServiceB_WhenCallServiceStarting_LoggerOutputStarting()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceB>>();

        var sut = new HostedServiceB(logger);
        await sut.StartingAsync(cancellationTokenSource.Token);

        logger.Received().LogDebug($"Service {nameof(HostedServiceB)} starting.");
    }

    [TestMethod]
    public async Task GivenHostedServiceB_WhenCallServiceStart_LoggerOutputStart()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceB>>();

        var sut = new HostedServiceB(logger);
        await sut.StartAsync(cancellationTokenSource.Token);

        logger.Received().LogDebug($"Service {nameof(HostedServiceB)} start.");
    }

    [TestMethod]
    public async Task GivenHostedServiceB_WhenCallServiceStarted_LoggerOutputStarted()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceB>>();

        var sut = new HostedServiceB(logger);
        await sut.StartedAsync(cancellationTokenSource.Token);

        logger.Received().LogDebug($"Service {nameof(HostedServiceB)} started.");
    }

    [TestMethod]
    public async Task GivenHostedServiceB_WhenCallServiceStopping_LoggerOutputStopping()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceB>>();

        var sut = new HostedServiceB(logger);
        await sut.StoppingAsync(cancellationTokenSource.Token);

        logger.Received().LogDebug($"Service {nameof(HostedServiceB)} stopping.");
    }

    [TestMethod]
    public async Task GivenHostedServiceB_WhenCallServiceStop_LoggerOutputStop()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceB>>();

        var sut = new HostedServiceB(logger);
        await sut.StopAsync(cancellationTokenSource.Token);

        logger.Received().LogDebug($"Service {nameof(HostedServiceB)} stop.");
    }

    [TestMethod]
    public async Task GivenHostedServiceB_WhenCallServiceStopped_LoggerOutputStopped()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceB>>();

        var sut = new HostedServiceB(logger);
        await sut.StoppedAsync(cancellationTokenSource.Token);

        logger.Received().LogDebug($"Service {nameof(HostedServiceB)} stopped.");
    }
}