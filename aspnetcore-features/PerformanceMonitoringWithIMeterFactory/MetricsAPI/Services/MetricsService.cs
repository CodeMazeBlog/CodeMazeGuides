using System.Diagnostics.Metrics;

namespace MetricsAPI.Services;

public class MetricsService : IMetricsService
{
    private readonly Counter<int> _userClicks;
    private readonly Histogram<double> _responseTime;

    private int _requests;
    private double _memoryConsumption;
    private double _cpu;
    private double _memory;
    private double _threadCount;

    public MetricsService(IMeterFactory meterFactory)
    {
        Meter meter = meterFactory.Create("Metrics.Service");

        _userClicks = meter.CreateCounter<int>("metrics.service.user_clicks");

        _responseTime = meter.CreateHistogram<double>(name: "metrics.service.response_time",
            unit: "Seconds",
            description: "This metric measures the time taken for the application to respond to user requests.");

        meter.CreateObservableCounter("metrics.service.requests", () => _requests);

        meter.CreateObservableGauge<double>(name: "metrics.service.memory_consumption",
            () => _memoryConsumption,
            unit: "Megabytes",
            description: "This metric measures the amount of memory used by the application.");

        meter.CreateObservableGauge(name: "metrics.service.resource_consumption",
            () => GetResourceConsumption());
    }
    public void RecordUserClick()
    {
        _userClicks.Add(1);
    }

    public void RecordResponseTime(double value)
    {
        _responseTime.Record(value);
    }

    public void RecordRequest()
    {
        Interlocked.Increment(ref _requests);
    }

    public void RecordMemoryConsumption(double value)
    {
        _memoryConsumption = value;
    }

    public void RecordUserClickDetailed(string region, string feature)
    {
        _userClicks.Add(1,
            new KeyValuePair<string, object?>("user.region", region),
            new KeyValuePair<string, object?>("user.feature", feature));
    }

    public void RecordResourceUsage(double currentCpuUsage, double currentMemoryUsage, double currentThreadCount)
    {
        _cpu = currentCpuUsage;
        _memory = currentMemoryUsage;
        _threadCount = currentThreadCount;
    }

    private IEnumerable<Measurement<double>> GetResourceConsumption()
    {
        return
        [
            new Measurement<double>(_cpu, new KeyValuePair<string,object?>
            ("resource_usage", "cpu")),
            new Measurement<double>(_memory, new KeyValuePair<string,object?>
            ("resource_usage", "memory")),
            new Measurement<double>(_threadCount, new KeyValuePair<string,object?>
            ("resource_usage", "thread_count")),
        ];
    }
}
