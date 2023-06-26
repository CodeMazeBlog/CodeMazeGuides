using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace DeterminingIfStringIsNumericOnly;

public partial class IsStringNumber
{
    [GeneratedRegex("^\\d+$")]
    private static partial Regex IsDigitRegex();
    
    [Benchmark]
    public bool IsNumericWithNewRegex() => new Regex("^\\d+$").IsMatch("123456789123456789");

    [Benchmark]
    public bool IsNumericWithCompiledRegex() => IsDigitRegex().IsMatch("123456789123456789");

    [Benchmark]
    public bool IsNumericWithTryParse() => int.TryParse("123456789123456789", out _);

    [Benchmark]
    public bool IsNumericWithForeachCharIsDigit()
    {
        foreach (var c in "123456789123456789")
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }

    [Benchmark]
    public bool IsNumericWithForeachCharIsBetween09()
    {
        foreach(var c in "123456789123456789")
        {
            if (c is < '0' or > '9')
                return false;
        }

        return true;
    }

    [Benchmark]
    public bool IsNumericWithLinqAllCharIsBetween09() => "123456789123456789".All(c => c is < '0' or > '9');
    
    [Benchmark]
    public bool IsNumericWithLinqAllCharIsDigit() => "123456789123456789".All(char.IsDigit);
}