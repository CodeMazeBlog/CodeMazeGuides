using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace ConvertHexadecimalToDecimal;

[MemoryDiagnoser]
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
public class ConversionExamples
{
    private const string hexVal = "7FFFFFFF";
    private const int decimalVal = int.MaxValue;

    [Benchmark]
    [Arguments(decimalVal)]
    public string DecimalToHexUsingToString(int decimalVal)
    {
        return decimalVal.ToString("X");
    }

    [Benchmark]
    [Arguments(decimalVal)]
    public string DecimalToHexUsingStringFormat(int decimalVal)
    {
        return string.Format("{0:X}", decimalVal);
    }

    [Benchmark]
    [Arguments(decimalVal)]
    public string DecimalToHexUsingBitwiseMethod(int decimalVal)
    {
        var hexVal = string.Empty;

        while (decimalVal > 0)
        {
            var remainder = decimalVal % 16;
            var hexDigit = remainder < 10 ? (char)(remainder + '0') : (char)(remainder - 10 + 'A');
            hexVal = hexDigit + hexVal;
            decimalVal /= 16;
        }

        return hexVal;
    }

    [Benchmark]
    [Arguments(hexVal)]
    public int HexToDecimalUsingParse(string hexVal)
    {
        return int.Parse(hexVal, System.Globalization.NumberStyles.HexNumber);
    }

    [Benchmark]
    [Arguments(hexVal)]
    public int HexToDecimalUsingConvert(string hexVal)
    {
        return Convert.ToInt32(hexVal, 16);
    }
}
