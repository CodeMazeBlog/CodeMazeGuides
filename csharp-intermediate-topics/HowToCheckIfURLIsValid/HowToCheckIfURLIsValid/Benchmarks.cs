using BenchmarkDotNet.Attributes;

namespace HowToCheckIfURLIsValid;

[MemoryDiagnoser]
[CsvExporter]
[MarkdownExporterAttribute.Default]
[MarkdownExporterAttribute.GitHub]
public class Benchmarks
{
    public const string Url = "https://site.company?q=search";

    [Benchmark]
    public void RegexUrlValidationBenchmark()
    {
        var success = UrlValidator.ValidateUrlWithRegex(Url);
    }
    
    [Benchmark]
    public void UriCreateValidationBenchmark()
    {
        var success = UrlValidator.ValidateUrlWithUriCreate(Url, out _);
    }
    
    [Benchmark]
    public void UriWellFormedStringValidationBenchmark()
    {
        var success = UrlValidator.ValidateUrlWithUriWellFormedString(Url);
    }
    
    [Benchmark]
    public async Task HttpClientValidationBenchmark()
    {
        var success = await UrlValidator.ValidateUrlWithHttpClient(Url);
    }
}