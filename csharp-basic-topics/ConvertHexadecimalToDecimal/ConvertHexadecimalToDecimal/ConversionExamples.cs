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
    private const string hexValue = "7FFFFFFF";
    private const int decimalValue = int.MaxValue;

    [Benchmark]
    [Arguments(decimalValue)]
    public string DecimalToHexUsingToString(int decimalVal)
    {
        return decimalVal.ToString("X");
    }

    [Benchmark]
    [Arguments(decimalValue)]
    public string DecimalToHexUsingStringFormat(int decimalVal)
    {
        return string.Format("{0:X}", decimalVal);
    }

    [Benchmark]
    [Arguments(decimalValue)]
    public string DecimalToHexUsingBitwiseMethod(int decimalVal)
    {
        var hexVal = string.Empty;
        var decimalNumber = decimalVal;

        while (decimalNumber > 0)
        {
            var remainder = decimalNumber % 16;
            var hexDigit = remainder < 10 ? (char)(remainder + '0') : (char)(remainder - 10 + 'A');
            hexVal = hexDigit + hexVal;
            decimalNumber /= 16;
        }

        return hexVal;
    }

    [Benchmark]
    [Arguments(hexValue)]
    public int HexToDecimalUsingParse(string hexVal)
    {
        return int.Parse(hexVal, System.Globalization.NumberStyles.HexNumber);
    }

    [Benchmark]
    [Arguments(hexValue)]
    public int HexToDecimalUsingConvert(string hexVal)
    {
        return Convert.ToInt32(hexVal, 16);
    }
}
