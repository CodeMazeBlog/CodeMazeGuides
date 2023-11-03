using System.Globalization;

namespace DecimalPrecision;

public static class StringFormat
{
    private static NumberFormatInfo CreateNumberFormatWithPrecision(int decimalPlaces)
    {
        return new NumberFormatInfo
        {
            NumberDecimalDigits = decimalPlaces
        };
    }

    public static string SetPrecisionUsingStringFormat(decimal myDecimal)
    {
        return myDecimal.ToString("0.00"); // "123.46"
    }
    
    public static string SetPrecisionUsingStringFormat(decimal myDecimal, int decimalPlaces)
    {
        NumberFormatInfo numberFormat = CreateNumberFormatWithPrecision(decimalPlaces);
        
        return myDecimal.ToString("N", numberFormat);
    }
}