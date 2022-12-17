using Serilog;
using Serilog.Formatting.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new JsonFormatter())
    .CreateLogger();

var meter = new Meter("OpenTelemetry");

var histogram = meter.CreateHistogram<float>("RequestDuration", unit: "ms");

var httpClient = new HttpClient();

Console.WriteLine("Press any key to start measurements");
Console.ReadLine();

var uri = "https://code-maze.com";

for (int i = 0; i < 100; i++)
{
    Log.Logger.Information("Starting request to {Url}", uri);
    var stopWatch = Stopwatch.StartNew();
    await httpClient.GetStringAsync(uri);

    histogram.Record(stopWatch.ElapsedMilliseconds, tag: KeyValuePair.Create<string, object?>("Url", uri));
}

Console.WriteLine("Measurements complete");
Console.ReadLine();