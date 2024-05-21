using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace BaseConversionInCSharp;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns([Column.StdDev, Column.Error])]
public class ConversionExamples
{
    private const string DigitValues = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string HexVal = "7FFFFFFF";
    private const int DecimalVal = int.MaxValue;
    private const int BinaryRadix = 2;
    private const int HexRadix = 16;

    [Benchmark]
    [Arguments(DecimalVal, BinaryRadix)]
    public string ConvertAnyBaseUsingToString(int decimalVal, int radixVal) 
    {
        if (radixVal == 2 || radixVal == 8 || radixVal == 10 || radixVal == 16)
        {
            return Convert.ToString(decimalVal, radixVal);
        }
        else
        { 
            throw new ArgumentException("Enter 2, 8, 10, or 16 as the radix");
        }
    }

    [Benchmark]
    [Arguments(DecimalVal, BinaryRadix)]
    public string DecimalToAnyBase(int decimalVal, int radixVal)
    {
        const int numOfBits = 32;

        if (radixVal < 2 || radixVal > 36) 
        {
            throw new ArgumentException("Enter radix between 2 and 36");
        }

        if (decimalVal == 0) 
        {
            return "0";
        }

        var digitValuesSpan = DigitValues.AsSpan();
        var position = numOfBits;
        var currentNumVal = Math.Abs(decimalVal);
        Span<char> resultArray = stackalloc char[numOfBits + 1];

        while (currentNumVal != 0)
        {
            var remainder = (int)(currentNumVal % radixVal);
            resultArray[position--] = digitValuesSpan[remainder];
            currentNumVal /= radixVal;
        }

        if (decimalVal < 0)
        {
            resultArray[position--] = '-';
        }

        var baseString = new string(resultArray[(position+1)..]);

        return baseString;
    }

    [Benchmark]
    [Arguments(HexVal, HexRadix)]
    public int AnyBaseToDecimalUsingConvert(string anyBaseVal, int radixVal)
    {
        if (radixVal == 2 || radixVal == 8 || radixVal == 10 || radixVal == 16)
        {
            return Convert.ToInt32(anyBaseVal, radixVal);
        }

        throw new ArgumentException("Enter 2, 8, 10, or 16 as the radix");
    }

    [Benchmark]
    [Arguments(HexVal, HexRadix)]
    public int AnyBaseToDecimal(string anyBaseVal, int radixVal)
    {
        if (radixVal < 2 || radixVal > 36) 
        {
            throw new ArgumentException("Radix should not be below 2 or above 36");
        }

        if (string.IsNullOrEmpty(anyBaseVal)) 
        {
            return 0;
        }

        var digitValuesSpan = DigitValues.AsSpan();

        var anyBaseSpan = anyBaseVal.AsSpan();
        var isNegative = false;

        if (anyBaseSpan[0] == '-')
        {
            isNegative = true;
            anyBaseSpan = anyBaseSpan[1..];
        }

        var decimalVal = 0;
        var multiplier = 1;

        for (int i = anyBaseSpan.Length - 1; i >= 0; i--)
        {
            var oneDigit = digitValuesSpan.IndexOf(anyBaseSpan[i]);
            if (oneDigit == -1) 
            {
                throw new ArgumentException("You have entered an invalid character", anyBaseVal);
            }
                
            decimalVal += oneDigit * multiplier;
            multiplier *= radixVal;
        }

        if (isNegative)
        {
            decimalVal = -decimalVal;
        }

        return decimalVal;
    }
}