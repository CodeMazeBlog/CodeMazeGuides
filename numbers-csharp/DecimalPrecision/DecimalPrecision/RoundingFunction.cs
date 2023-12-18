namespace DecimalPrecision;

public static class RoundingFunction
{
public static decimal Round(this decimal value, int decimalPlaces) => decimal.Round(value, decimalPlaces);

public static decimal Truncate(this decimal value) => decimal.Truncate(value);

public static decimal Ceiling(this decimal value) => decimal.Ceiling(value);

public static decimal Floor(this decimal value) => decimal.Floor(value);
}