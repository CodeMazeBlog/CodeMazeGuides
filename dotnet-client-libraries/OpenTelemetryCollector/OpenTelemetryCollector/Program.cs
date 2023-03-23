using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryCollector;
using System.Diagnostics;

var activitySource = new ActivitySource("OpenTelemetryCollector");

using var traceProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("OpenTelemetryCollector")
    .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName: "OpenTelemetryCollector"))
    .AddConsoleExporter()
    .AddOtlpExporter(opt =>
    {
        opt.Protocol = OtlpExportProtocol.Grpc;
        opt.Endpoint = new Uri("http://localhost:4317");
    })
    .Build();

using var activity = activitySource.StartActivity("Root trace");

var traces = new Traces(activitySource);

await traces.LongRunningTask();

