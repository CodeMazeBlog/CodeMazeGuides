namespace StandardAndCustomFormatStrings;

public class CustomFormatStrings
{
    public static string Decimal(double number) => number.ToString("00000");          
    public static string FloatingPoint(double number) => number.ToString("0000.00"); 
    public static string Percentage(double number) => number.ToString("0.00%");
    public static string DigitSeparator(double number) => number.ToString("#,###.00");  
    public static string Phone(long value) => String.Format("{0:(###) ###-####}", value);
    public static string PhoneInterpolated(long value) => $"{value:(###) ###-####}";
}