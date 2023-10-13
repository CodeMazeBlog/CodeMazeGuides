using System.Globalization;

namespace DecimalPrecision;

public class StringFormat
{
    private static NumberFormatInfo CreateNumberFormatWithPrecision(int decimalPlaces)
    {
        NumberFormatInfo numberFormat = new NumberFormatInfo
        {
            NumberDecimalDigits = decimalPlaces
        };
        
        return numberFormat;
    }

    public string SetPrecisionUsingStringFormat(decimal myDecimal)
    {
        string formatted = myDecimal.ToString("0.00"); // "123.46"
        
        return formatted;
    }
    
    public string SetPrecisionUsingStringFormatAndGlobalScope(decimal myDecimal, int decimalPlaces)
    {
        NumberFormatInfo numberFormat = CreateNumberFormatWithPrecision(decimalPlaces);
        string formatted = myDecimal.ToString("N", numberFormat);
        
        return formatted;
    }
}