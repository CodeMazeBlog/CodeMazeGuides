using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace CheckNumberInString;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
[HideColumns(Column.RatioSD, Column.AllocRatio)]
public class BenchmarkProcess
{
    private const string InputString = "The price is $42.75 for two items and $18.50 for one item.";

    [Benchmark]
    public string ExtractNumberUsingRegExMethod()
    {
        return  ExtractNumber.ExtractNumberUsingRegEx(InputString);
    }

    [Benchmark(Baseline = true)]
    public string ExtractNumberUsingLinqMethod()
    {
        return ExtractNumber.ExtractNumbersUsingLinq(InputString);
    }

    [Benchmark]
    public string ExtractNumberUsingStringBuilderMethod()
    {
        return ExtractNumber.ExtractNumberUsingStringBuilder(InputString);
    }

    [Benchmark]
    public string ExtractNumberUsingSpanMethod()
    {
        return ExtractNumber.ExtractNumberUsingSpan(InputString);
    }
}