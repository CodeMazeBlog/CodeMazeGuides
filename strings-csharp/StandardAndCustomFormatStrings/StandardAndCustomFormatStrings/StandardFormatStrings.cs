using System.Globalization;

namespace StandardAndCustomFormatStrings;

public static class StandardFormatStrings
{
  public static string CurrencyFormat(double value) => value.ToString("C");
  public static string EuroCurrency(double value) => value.ToString("C", new CultureInfo("fr-FR"));
  public static string DecimalFormat(int value) => value.ToString("D");
  public static string FixedPointFormat(double value) => value.ToString("F");
  public static string DecimalPrecision(int value) => value.ToString("D5");
  public static string FloatingPointPrecision(double value) => value.ToString("F2");
  public static string Percentage(double value) => $"{value:P2}";
  public static string FixedPointPrecisionDecimal(decimal value) => value.ToString("F2");
  public static string Aligned(double value) => string.Format("{0,12:N2}", value);
  public static string AlignedInterpolated(double value) => $"{value,-12:N2}";

  public static bool TryFormatFixedPoint(double value, Span<char> destination, out int charsWritten) =>
    value.TryFormat(destination, out charsWritten, "F2", CultureInfo.InvariantCulture);
}