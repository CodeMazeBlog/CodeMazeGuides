using OpenTelemetryCollector;
using System.Diagnostics;

namespace Tests;

public class TracesTests
{
    private readonly ActivitySource _activitySource;
    private readonly Traces _traces;

    public TracesTests()
    {
        _activitySource = new ActivitySource("UnitTests");
        _traces = new Traces(_activitySource);
    }

    [Fact]
    public async void GivenTraces_WhenCallingLongRunningTaskMethod_ThenCreatesNewActivity()
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
        await _traces.LongRunningTask();

        // Assert
        Assert.Single(activitiesStarted);
    }
}
