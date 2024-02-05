using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ConvertHexadecimalToDecimal;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns([Column.StdDev, Column.Error])]
public class ConversionExamples
{
    private const string HexValue = "7FFFFFFF";
    private const int DecimalValue = int.MaxValue;

    [Benchmark]
    [Arguments(DecimalValue)]
    public string DecimalToHexUsingToString(int decimalVal)
    {
        return decimalVal.ToString("X");
    }

    [Benchmark]
    [Arguments(DecimalValue)]
    public string DecimalToHexUsingStringFormat(int decimalVal)
    {
        return string.Format("{0:X}", decimalVal);
    }

    [Benchmark]
    [Arguments(DecimalValue)]
public string DecimalToHexUsingBitwiseMethod(int decimalVal)
{
    const int hexBaseOffset = 'A' - 0xA; 
    var hexStringLength = (BitOperations.Log2((uint) decimalVal) >> 2) + 1;

    return string.Create(hexStringLength, decimalVal, (span, value) =>
    {
        for (int i = span.Length - 1; i >= 0; i--)
        {
            var digit = (byte) (value & 0xF);
            span[i] = (char) (digit + (digit < 10 ? '0' : hexBaseOffset));
            value >>= 4;
        }
    });
}

    [Benchmark]
    [Arguments(HexValue)]
    public int HexToDecimalUsingParse(string hexVal)
    {
        return int.Parse(hexVal, System.Globalization.NumberStyles.HexNumber);
    }

    [Benchmark]
    [Arguments(HexValue)]
    public int HexToDecimalUsingConvert(string hexVal)
    {
        return Convert.ToInt32(hexVal, 16);
    }
}
