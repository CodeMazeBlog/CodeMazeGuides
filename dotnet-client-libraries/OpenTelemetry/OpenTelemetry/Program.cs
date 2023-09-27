using OpenTelemetry;
using Serilog;
using Serilog.Formatting.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new JsonFormatter())
    .CreateLogger();

// Pillar 1: Traces
Console.WriteLine("Starting trace pillar");
var tracingPillar = new Traces();
await tracingPillar.Start();
Console.WriteLine("Trace pillar complete. Press any key to start metrics pillar");
Console.ReadLine();

// Pillar 2: Metrics
Console.WriteLine("Starting metrics pillar");
var metricsPillar = new Metrics(new HttpClient());
await metricsPillar.Start();
Console.WriteLine("Metrics pillar complete. Press any key to start logging pillar");
Console.ReadLine();

// Pillar 3: Logging
Console.WriteLine("Starting logging pillar");
var loggingPillar = new Logging(Log.Logger);
await loggingPillar.Start();
Console.WriteLine("Logging pillar complete. Press any key to finish");

Console.ReadLine();