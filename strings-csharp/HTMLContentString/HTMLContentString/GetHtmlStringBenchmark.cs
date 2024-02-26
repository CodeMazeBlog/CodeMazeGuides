using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace HTMLContentString;

[MemoryDiagnoser]
[CsvExporter]
[MarkdownExporterAttribute.Default]
[MarkdownExporterAttribute.GitHub]
[HideColumns(Column.StdDev, Column.Gen0, Column.Gen1)]
public class GetHtmlStringBenchmark
{
    private readonly string _url = "https://www.wikipedia.org/";
    private readonly HtmlHttp _htmlHttp;
    private readonly HtmlAgility _htmlAgility;
    private readonly HtmlAngle _htmlAngle;
    
    public GetHtmlStringBenchmark()
    {
        _htmlHttp = new ();
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