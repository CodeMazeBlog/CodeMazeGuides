using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTelemetry;
public class Metrics : IPillar
{
    private readonly HttpClient _httpClient;
    private static readonly Meter _meter = new("OpenTelemetry");

    public Metrics(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Start()
    {
        var histogram = _meter.CreateHistogram<float>("RequestDuration", unit: "ms");

        var uri = "https://code-maze.com";

        for (int i = 0; i < 100; i++)
        {
            var stopWatch = Stopwatch.StartNew();
            await _httpClient.GetStringAsync(uri);

            histogram.Record(stopWatch.ElapsedMilliseconds, tag: KeyValuePair.Create<string, object?>("Url", uri));
        }
    }
}
