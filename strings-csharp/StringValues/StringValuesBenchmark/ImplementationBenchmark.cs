using BenchmarkDotNet.Attributes;

[Config(typeof(AntiVirusFriendlyConfig))]
[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class ImplementationBenchmark
{
    private NaiveImplementation? _naiveImplementation;
    private StringValuesImplementation? _stringValuesImplementation;
    private LegacyImplementation? _legacyImplementation;

    [GlobalSetup]
    public void Setup()
    {
        _naiveImplementation = new NaiveImplementation();
        _stringValuesImplementation = new StringValuesImplementation();
        _legacyImplementation = new LegacyImplementation();
    }

    [Benchmark]
    public void AddMultipleHeadersUsingStringValues()
    {
        for (int i = 0; i < 5; i++)
        {
            _stringValuesImplementation?.AddHeader("MyHeader", $"value{i}");
        }
    }

    [Benchmark]
    public void AddMultipleHeadersUsingNaiveMethod()
    {
        for (int i = 0; i < 5; i++)
        {
            _naiveImplementation?.AddHeader("MyHeader", $"value{i}");
        }
    }

    [Benchmark]
    public void AddMultipleHeadersUsingLegacyImplementation()
    {
        for (int i = 0; i < 5; i++)
        {
            _legacyImplementation?.AddHeader("MyHeader", $"value{i}");
        }
    }
}
