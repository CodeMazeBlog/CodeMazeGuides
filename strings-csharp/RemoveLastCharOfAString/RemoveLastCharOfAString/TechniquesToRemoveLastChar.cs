using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using System.Text;

namespace RemoveLastCharOfAString;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns([Column.StdDev, Column.Error])]

public class TechniquesToRemoveLastChar
{
    private const string TestString = "2147483647";

    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingRemove(string inputString) 
    {
        return inputString.Remove(inputString.Length - 1);
    }

    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingSubstring(string inputString) 
    {
        return inputString.Substring(0, inputString.Length - 1);
    }

    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingLinq(string inputString) 
    {
        return new string(inputString.Take(inputString.Length - 1).ToArray());
    }

    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingSpan(string inputString) 
    {
        var inputSpan = inputString.AsSpan();
        inputSpan = inputSpan.Slice(0, inputSpan.Length - 1);

        return new string(inputSpan);
    }

    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingStringBuilder(string inputString) 
    {
        var stringBuilder = new StringBuilder(inputString);
        stringBuilder.Remove(stringBuilder.Length - 1, 1);

        return stringBuilder.ToString();
    }
}