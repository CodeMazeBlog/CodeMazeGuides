using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using MetricsAPI.Services;

namespace Tests;

public class MetricsTests
{
    [Fact]
    public void GivenMetricsConfigured_WhenUserClickRecorded_ThenCounterCaptured()
    {
        // Arrange
        using var services = CreateServiceProvider();
        var metrics = services.GetRequiredService<MetricsService>();
        var meterFactory = services.GetRequiredService<IMeterFactory>();
        var collector = new MetricCollector<int>(meterFactory, "Metrics.Service", "metrics.service.user_clicks");

        // Act
        metrics.RecordUserClick();

        // Assert
        var measurements = collector.GetMeasurementSnapshot();
        Assert.Single(measurements);
        Assert.Equal(1, measurements[0].Value);
    }

    [Fact]
    public void GivenMetricsConfigured_WhenRequestRecorded_ThenObservableCounterCaptured()
    {
        // Arrange
        using var services = CreateServiceProvider();
        var metrics = services.GetRequiredService<MetricsService>();
        var meterFactory = services.GetRequiredService<IMeterFactory>();
        var collector = new MetricCollector<int>(meterFactory, "Metrics.Service", "metrics.service.requests");

        // Act
        metrics.RecordRequest();

        // Assert
        collector.RecordObservableInstruments();
        var measurements = collector.GetMeasurementSnapshot();
        Assert.Single(measurements);
        Assert.Equal(1, measurements[0].Value);
    }

    private static ServiceProvider CreateServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMetrics();
        serviceCollection.AddSingleton<MetricsService>();

        return serviceCollection.BuildServiceProvider();
    }
}