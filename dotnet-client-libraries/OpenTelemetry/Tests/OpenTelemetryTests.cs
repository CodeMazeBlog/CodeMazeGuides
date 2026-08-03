using Moq;
using OpenTelemetry;
using RichardSzalay.MockHttp;
using Serilog;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Tests;

public class OpenTelemetryTests
{
    private readonly ActivitySource _activitySource;
    private readonly IPillar _tracingPillar;

    private readonly MockHttpMessageHandler _mockHttpMessageHandler;
    private IPillar _metricsPillar;

    private readonly Mock<ILogger> _logger;
    private readonly IPillar _loggingPillar;

    public OpenTelemetryTests()
    {
        _activitySource = new ActivitySource("UnitTests");
        _tracingPillar = new Traces(/*_activitySource*/);

        _mockHttpMessageHandler = new MockHttpMessageHandler();

        _logger = new Mock<ILogger>();
        _loggingPillar = new Logging(_logger.Object);
    }

    [Fact]
    public async void GivenTracingProvider_WhenCallingStartMethod_ThenCreatesNewActivity()
    {
        // Arrange
        var activitiesStarted = new List<Activity>();
        var activityListener = new ActivityListener
        {
            ShouldListenTo = s => true,
            SampleUsingParentId = (ref ActivityCreationOptions<string> activityOptions) => ActivitySamplingResult.AllData,
            Sample = (ref ActivityCreationOptions<ActivityContext> activityOptions) => ActivitySamplingResult.AllData,
            ActivityStarted = activitiesStarted.Add
        };
        ActivitySource.AddActivityListener(activityListener);

        // Act
        await _tracingPillar.Start();

        // Assert
        Assert.Equal(2, activitiesStarted.Count);
    }

    [Fact]
    public async void GivenMetricsPillar_WhenCallingStartMethod_ThenMakesRequestsToCodeMaze()
    {
        // Arrange
        _mockHttpMessageHandler.When("https://code-maze.com").Respond("text/plain", "code maze response");
        _metricsPillar = new Metrics(_mockHttpMessageHandler.ToHttpClient());

        // Act
        await _metricsPillar.Start();

        // Assert
        _mockHttpMessageHandler.VerifyNoOutstandingRequest();
    }

    [Fact]
    public async void GivenLoggingPillar_WhenCallingStartMethod_ThenCreatesInformationLogs()
    {
        // Act
        await _loggingPillar.Start();

        // Assert
        _logger.Verify(l => l.Information(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
    }
}