using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Order;
using Microsoft.Extensions.DependencyInjection;

namespace HTMLContentString;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporterAttribute.Default]
[HideColumns(Column.StdDev, Column.Gen0, Column.Gen1)]
public class GetHtmlStringBenchmark
{
    private readonly string _url = "https://www.wikipedia.org/";
    private  HtmlHttp _htmlHttp;
    private  HtmlAgility _htmlAgility;
    private  HtmlAngle _htmlAngle;
    private IServiceProvider _serviceProvider;
    
    [GlobalSetup]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();

        _serviceProvider = services.BuildServiceProvider();
        _htmlHttp = new (_serviceProvider.GetRequiredService<IHttpClientFactory>());
        _htmlAgility = new();
        _htmlAngle = new();
    }
    
    [Benchmark]
    public async Task GetHtmlAsStringHttpClient()
    {
        await _htmlHttp.GetHtmlAsStringAsync(_url);
    }
    
    [Benchmark]
    public void GetHtmlAsStringHtmlAgilityPack()
    {
        _htmlAgility.GetHtmlAsString(_url);
    }
    
    [Benchmark]
    public async Task GetHtmlAsStringAngleSharp()
    {
        await _htmlAngle.GetHtmlAsStringAsync(_url);
    }
}