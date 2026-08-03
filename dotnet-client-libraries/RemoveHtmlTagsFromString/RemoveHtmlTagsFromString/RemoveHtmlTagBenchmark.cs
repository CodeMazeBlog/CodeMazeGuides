using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace RemoveHtmlTagsFromString;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
public class RemoveHtmlTagBenchmark
{
    private string HTML_TEXT = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        HTML_TEXT = File.ReadAllText("./long.html");
    }

    [Benchmark(Description = "UseRegularExpression")]
    public void Benchmark_UseRegularExpression()
    {
        HtmlTagRemover.UseRegularExpression(HTML_TEXT);
    }

    [Benchmark(Description = "UseHtmlDecode")]
    public void Benchmark_UseHtmlDecode()
    {
        HtmlTagRemover.UseHtmlDecode(HTML_TEXT);
    }

    [Benchmark(Description = "UseHtmlAgilityPack")]
    public void Benchmark_UseHtmlAgilityPack()
    {
        HtmlTagRemover.UseHtmlAgilityPack(HTML_TEXT);
    }

    [Benchmark(Description = "UseAngleSharp")]
    public void Benchmark_UseAngleSharp()
    {
        HtmlTagRemover.UseAngleSharp(HTML_TEXT);
    }

    [Benchmark(Description = "UseXmlXElement")]
    public void Benchmark_UseXmlXElement()
    {
        HtmlTagRemover.UseXmlXElement(HTML_TEXT);
    }
}
