using System.Globalization;

namespace DecimalPrecision;

public class StringFormat
{
    private readonly NumberFormatInfo _setPrecision = new NumberFormatInfo(){NumberDecimalDigits = 2};

    public string SetPrecisionUsingStringFormat(decimal myDecimal)
    {
        string formatted = myDecimal.ToString("0.00"); // "123.46"
        
        return formatted;
    }
    
    public string SetPrecisionUsingStringFormatAndGlobalScope(decimal myDecimal)
    {
        string formatted = myDecimal.ToString("N",_setPrecision); // "123.46"
        
        return formatted;
    }
}