using System.Globalization;

namespace DecimalPrecision;

public static class StringFormat
{
    public static string SetPrecisionUsingStringFormat(decimal myDecimal)
    {
        return myDecimal.ToString("0.00"); 
    }

    public static string SetPrecisionUsingStringFormatInfo(decimal myDecimal, int decimalPlaces)
    {
        var numberFormat = new NumberFormatInfo
        {
            NumberDecimalDigits = decimalPlaces
        };

        return myDecimal.ToString("N", numberFormat);
    }
}