using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTelemetry;
public class Traces : IPillar
{
    private static readonly ActivitySource _activitySource = new("OpenTelemetry");

    public async Task Start()
    {
        using var activity = _activitySource.StartActivity("Start method");
        await ChildMethod();
    }

    private async Task ChildMethod()
    {
        using var activity = _activitySource.StartActivity("Child method");
        await Task.Delay(500);
    }
}
