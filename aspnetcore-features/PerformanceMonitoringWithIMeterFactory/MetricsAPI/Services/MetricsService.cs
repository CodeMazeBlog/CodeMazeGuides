using System.Diagnostics.Metrics;

namespace MetricsAPI.Services;

public class MetricsService : IMetricsService
{
    private readonly Counter<int> userClicks;
    private readonly Histogram<double> responseTime;

    private int requests;
    private double memoryConsumption;
    private int cpu;
    private int memory;
    private int threadCount;

    public MetricsService(IMeterFactory meterFactory)
    {
        Meter meter = meterFactory.Create("Metrics.Service");

        userClicks = meter.CreateCounter<int>("metrics.service.user_clicks");

        responseTime = meter.CreateHistogram<double>(name: "metrics.service.response_time",
            unit: "Seconds",
            description: "This metric measures the time taken for the application to respond to user requests.");

        meter.CreateObservableCounter("metrics.service.requests", () => requests);

        meter.CreateObservableGauge(name: "metrics.service.memory_consumption",
            () => memoryConsumption,
            unit: "Megabytes",
            description: "This metric measures the amount of memory used by the application.");

        meter.CreateObservableGauge(name: "metricsservice.resource_consumption",
            () => GetResourceConsumption());
    }

    public void RecordUserClick()
    {
        userClicks.Add(1);
    }

    public void RecordResponseTime(double value)
    {
        responseTime.Record(value);
    }

    public void RecordRequest()
    {
        requests += 1;
    }

    public void RecordMemoryConsumption(double value)
    {
        memoryConsumption = value;
    }

    public void RecordUserClickDetailed(string region, string feature)
    {
        userClicks.Add(1,
            new KeyValuePair<string, object?>("user.region", region),
            new KeyValuePair<string, object?>("user.feature", feature));
    }

    public void RecordResourceUsage(int currentCpuUsage, int currentMemoryUsage, int currentThreadCount)
    {
        cpu = currentCpuUsage;
        memory = currentMemoryUsage;
        threadCount = currentThreadCount;
    }

    private IEnumerable<Measurement<int>> GetResourceConsumption()
    {
        return
        [
            new Measurement<int>(cpu, new KeyValuePair<string,object?>
            ("resource_usage", "cpu")),
            new Measurement<int>(memory, new KeyValuePair<string,object?>
            ("resource_usage", "memory")),
            new Measurement<int>(threadCount, new KeyValuePair<string,object?>
            ("resource_usage", "thread_count")),
        ];
    }
}
