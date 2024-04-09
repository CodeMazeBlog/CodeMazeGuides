using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class Benchmarking
{
    public string str = new("Lorem".ToCharArray()[0], 5);
    public string toFind = "Lorem";

    [Benchmark]
    public void FindAllIndexesWithIndexOf()
    {
        SubstringSearchMethods.FindAllIndexesWithIndexOf(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSubstring()
    {
        SubstringSearchMethods.FindAllIndexesWithSubstring(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSplit()
    {
        SubstringSearchMethods.FindAllIndexesWithSplit(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithLINQ()
    {
        SubstringSearchMethods.FindAllIndexesWithLINQ(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithRegex()
    {
        SubstringSearchMethods.FindAllIndexesWithRegex(str, toFind);
    }

    [Benchmark]
    public void FindAllIndexesWithSpan()
    {
        SubstringSearchMethods.FindAllIndexesWithSpan(str, toFind);
    }
}
