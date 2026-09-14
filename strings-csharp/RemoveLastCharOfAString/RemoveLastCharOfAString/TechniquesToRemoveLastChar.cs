using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using System.Globalization;
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
    public string RemoveLastCharUsingRange(string inputString)
    {
        return inputString[..^1];
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
    public string RemoveLastCharUsingStringBuilderLength(string inputString) 
    {
        var stringBuilder = new StringBuilder(inputString);
        --stringBuilder.Length;

        return stringBuilder.ToString();
    }

    [Benchmark]
    [Arguments(TestString)]
    public string RemoveLastCharUsingStringBuilderRemove(string inputString)
    {
        var stringBuilder = new StringBuilder(inputString);
        stringBuilder.Remove(stringBuilder.Length - 1, 1);

        return stringBuilder.ToString();
    }

    public static string RemoveLastTextElement(string input)
    {
        if (input.Length == 0)
            return input;

        var enumerator = StringInfo.GetTextElementEnumerator(input);
        var lastStart = 0;

        while (enumerator.MoveNext())
            lastStart = enumerator.ElementIndex;

        return input[..lastStart];
    }

}