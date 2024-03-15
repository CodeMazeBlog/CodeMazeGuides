using System.Diagnostics;

namespace OpenTelemetryCollector;
public class Traces
{
    private readonly ActivitySource _activitySource;

    public Traces(ActivitySource activitySource)
    {
        _activitySource = activitySource;
    }

    public async Task LongRunningTask()
    {
        using var activity = _activitySource.StartActivity("Long running task");

        await Task.Delay(1000);

        activity.AddEvent(new ActivityEvent("Long running task complete"));
    }
}
