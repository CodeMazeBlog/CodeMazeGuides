using System.Globalization;

namespace DecimalPrecision;

public static class StringFormat
{
    public static string FormatDecimalWithPrecision(decimal myDecimal, string format)
    {
        return myDecimal.ToString(format);
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