using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace DeterminingIfStringIsNumericOnly;

[Orderer(SummaryOrderPolicy.SlowestToFastest)]
public partial class IsStringNumber
{
    private const string IntegerString = "123456789123456789";

    [GeneratedRegex("^\\d+$")]
    private static partial Regex IsDigitRegex();
    
    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithNewRegex(string input) => new Regex("^\\d+$").IsMatch(input);

    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithCompiledRegex(string input) => IsDigitRegex().IsMatch(input);

    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithTryParse(string input) => int.TryParse(input, out _);

    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithForeachCharIsDigit(string input)
    {
        foreach (var c in input)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }

    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithForeachCharIsBetween09(string input)
    {
        foreach(var c in input)
        {
            if (c is < '0' or > '9')
                return false;
        }

        return true;
    }

    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithLinqAllCharIsBetween09(string input) => input.All(c => c is >= '0' and <= '9');
    
    [Benchmark]
    [Arguments(IntegerString)]
    public bool IsNumericWithLinqAllCharIsDigit(string input) => input.All(char.IsDigit);
}