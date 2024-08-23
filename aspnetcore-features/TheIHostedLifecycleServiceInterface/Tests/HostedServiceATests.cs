using Microsoft.Extensions.Logging;
using NSubstitute;
using TheIHostedLifecycleServiceInterface.Services;

namespace Tests;

[TestClass]
public class HostedServiceATests
{
    [TestMethod]
    public async Task GivenHostedServiceA_WhenCallServiceStarting_LoggerOutputStarting()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceA>>();

        var sut = new HostedServiceA(logger);
        await sut.StartingAsync(cancellationTokenSource.Token);

        logger.Received().LogInformation($"Service {nameof(HostedServiceA)} starting.");
    }

    [TestMethod]
    public async Task GivenHostedServiceA_WhenCallServiceStart_LoggerOutputStart()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceA>>();

        var sut = new HostedServiceA(logger);
        await sut.StartAsync(cancellationTokenSource.Token);

        logger.Received().LogInformation($"Service {nameof(HostedServiceA)} start.");
    }

    [TestMethod]
    public async Task GivenHostedServiceA_WhenCallServiceStarted_LoggerOutputStarted()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceA>>();

        var sut = new HostedServiceA(logger);
        await sut.StartedAsync(cancellationTokenSource.Token);

        logger.Received().LogInformation($"Service {nameof(HostedServiceA)} started.");
    }

    [TestMethod]
    public async Task GivenHostedServiceA_WhenCallServiceStopping_LoggerOutputStopping()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceA>>();

        var sut = new HostedServiceA(logger);
        await sut.StoppingAsync(cancellationTokenSource.Token);

        logger.Received().LogInformation($"Service {nameof(HostedServiceA)} stopping.");
    }

    [TestMethod]
    public async Task GivenHostedServiceA_WhenCallServiceStop_LoggerOutputStop()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceA>>();

        var sut = new HostedServiceA(logger);
        await sut.StopAsync(cancellationTokenSource.Token);

        logger.Received().LogInformation($"Service {nameof(HostedServiceA)} stop.");
    }

    [TestMethod]
    public async Task GivenHostedServiceA_WhenCallServiceStopped_LoggerOutputStopped()
    {
        var cancellationTokenSource = new CancellationTokenSource(1000);
        var logger = Substitute.For<ILogger<HostedServiceA>>();

        var sut = new HostedServiceA(logger);
        await sut.StoppedAsync(cancellationTokenSource.Token);

        logger.Received().LogInformation($"Service {nameof(HostedServiceA)} stopped.");
    }
}