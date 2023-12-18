using System.Globalization;

namespace DecimalPrecision;

public static class StringFormat
{
public static string ToStringXDecimalPlaces(this decimal val, int decimalPlaces)
{
    var format = new NumberFormatInfo
    {
        NumberDecimalDigits = decimalPlaces
    };

    return val.ToString("F", format);
}

}