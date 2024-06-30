using BenchmarkDotNet.Attributes;
public class ImplementationBenchmark
{
    [Benchmark]
    public void AddMultipleHeadersUsingNaiveMethod()
    {
        NaiveImplementation naiveImplementation = new();

        for (int i = 0; i < 5; i++)
        {
            naiveImplementation.AddHeader("MyHeader", $"value{i}");
        }
    }

    [Benchmark]
    public void AddMultipleHeadersUsingLegacyImplementation()
    {
        LegacyImplementation legacyImplementation = new();

        for (int i = 0; i < 5; i++)
        {
            legacyImplementation.AddHeader("MyHeader", $"value{i}");
        }
    }

    [Benchmark]
    public void AddMultipleHeadersUsingStringValues()
    {
        StringValuesImplementation stringValuesImplementation = new();

        for (int i = 0; i < 5; i++)
        {
            stringValuesImplementation?.AddHeader("MyHeader", $"value{i}");
        }
    }
}
