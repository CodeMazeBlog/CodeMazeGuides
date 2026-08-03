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
        var inputSpan = inputString.AsSpan()[..^1];

        return new string(inputSpan);
    }

    [Benchmark]
    [Arguments(TestString)]
    public ReadOnlySpan<char> RemoveLastCharAsSpan(string inputString)
    {
        return inputString.AsSpan()[..^1];
    }


    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingStringBuilder(string inputString) 
    {
        var stringBuilder = new StringBuilder(inputString);
        --stringBuilder.Length;

        return stringBuilder.ToString();
    }

}