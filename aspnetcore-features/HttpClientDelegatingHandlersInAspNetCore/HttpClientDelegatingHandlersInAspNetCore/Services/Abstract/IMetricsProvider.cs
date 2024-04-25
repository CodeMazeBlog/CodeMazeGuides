namespace HttpClientDelegatingHandlersInAspNetCore.Services.Abstract;

public interface IMetricsProvider : IDisposable
{
    IDisposable MeasureTime(string uriPath);
}