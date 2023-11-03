namespace DecimalPrecision;

public static class RoundingFunction
{
    public static decimal GetDecimalRoundValueUsingMathRound(decimal value)
    {
        return Math.Round(value, 2);
    }
    
    public static decimal GetDecimalRoundValueUsingDecimalRound(decimal value)
    {
        return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    }
    
    public static decimal GetDecimalRoundValueUsingDecimalTruncate(decimal value)
    {
        return decimal.Truncate(value);
    }
}