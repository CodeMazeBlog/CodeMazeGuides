using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ImplementationBenchmark
{
    [Benchmark]
    public void AddMultipleHeadersUsingStringValues()
    {
        for (int i = 0; i < 5; i++)
        {
            StringValuesImplementation.AddHeader("MyHeader", $"value{i}");
        }
    }

    [Benchmark]
    public void AddMultipleHeadersUsingNaiveMethod()
    {
        for (int i = 0; i < 5; i++)
        {
            NaiveImplementation.AddHeader("MyHeader", $"value{i}");
        }
    }

    [Benchmark]
    public void AddMultipleHeadersUsingLegacyImplementation()
    {
        for (int i = 0; i < 5; i++)
        {
            LegacyImplementation.AddHeader("MyHeader", $"value{i}");
        }
    }
}
