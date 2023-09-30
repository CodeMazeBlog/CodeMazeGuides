using System.Globalization;

namespace StandardAndCustomFormatStrings;

public class StandardFormatStrings
{
    public static string CurrencyFormat(double value) => value.ToString("C");
    public static string EuroCurrency(double value) => value.ToString("C", new CultureInfo("fr-FR"));
    public static string DecimalFormat(int value) => value.ToString("D");
    public static string FixedPointFormat(double value) => value.ToString("F");
    public static string DecimalPrecision(int value) => value.ToString("D5");
    public static string FloatingPointPrecision(double value) => value.ToString("F2");
    public static string Percentage(double value) => $"{value:P2}";
}