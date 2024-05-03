using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace BaseConversionInCSharp;

[MemoryDiagnoser]
[RankColumn]
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
    public string ConvertAnyBaseUsingToString(int inputVal, int radixVal) 
    {
        if (radixVal == 2 || radixVal == 8 || radixVal == 10 || radixVal == 16)
        {
            return Convert.ToString(inputVal, radixVal);
        }
        else
        { 
            throw new ArgumentException("Enter 2, 8, 10, or 16 as the radix");
        }
    }

    [Benchmark]
    [Arguments(DecimalVal, BinaryRadix)]
    public string DecimalToAnyBase(long decimalVal, int radixVal)
    {
        const int numOfBits = 64;

        if (radixVal < 2 || radixVal > 36) 
        {
            throw new ArgumentException("Enter radix between 2 and 36");
        }

        if (decimalVal == 0) 
        {
            return "0";
        }

        var position = numOfBits - 1;
        var currentNumVal = Math.Abs(decimalVal);
        var resultArray = new char[numOfBits];

        while (currentNumVal != 0)
        {
            var remainder = (int)(currentNumVal % radixVal);
            resultArray[position--] = DigitValues[remainder];
            currentNumVal = currentNumVal / radixVal;
        }

        var baseString = new String(resultArray, position + 1, numOfBits - position - 1);

        if (decimalVal < 0)
        {
            baseString = $"-{baseString}";
        }

        return baseString;
    }

    [Benchmark]
    [Arguments(HexVal, HexRadix)]
    public decimal AnyBaseToDecimalUsingConvert(string anyBaseVal, int radixVal) 
    {
        if (radixVal == 2 || radixVal == 8 || radixVal == 10 || radixVal == 16)
        {
            return Convert.ToInt32(anyBaseVal, radixVal);
        }
        else
        {
            throw new ArgumentException("Enter 2, 8, 10, or 16 as the radix");
        }
    }

    [Benchmark]
    [Arguments(HexVal, HexRadix)]
    public decimal AnyBaseToDecimal(string anyBaseVal, int radixVal)
    {
        if (radixVal < 2 || radixVal > 36) 
        {
            throw new ArgumentException("Radix should not be below 2 or above 36");
        }

        if (String.IsNullOrEmpty(anyBaseVal)) 
        {
            return 0;
        }

        anyBaseVal = anyBaseVal.ToUpperInvariant();

        var decimalVal = 0;
        var quotient = 1;

        for (int i = anyBaseVal.Length - 1; i >= 0; i--)
        {
            var singleChar = anyBaseVal[i];

            if (i == 0 && singleChar == '-')
            {
                decimalVal = -decimalVal;
                break;
            }

            var oneDigit = DigitValues.IndexOf(singleChar);

            if (oneDigit == -1) 
            {
                throw new ArgumentException( "You have entered an invalid character", anyBaseVal);
            }
                
            decimalVal += oneDigit * quotient;
            quotient *= radixVal;
        }

        return decimalVal;
    }
}