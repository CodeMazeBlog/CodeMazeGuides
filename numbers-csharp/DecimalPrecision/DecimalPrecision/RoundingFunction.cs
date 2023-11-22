namespace DecimalPrecision;

public static class RoundingFunction
{
    public static decimal GetDecimalRoundValueUsingMathRound(decimal value)
    {
        return Math.Round(value, 2);
    }
    
    public static decimal GetDecimalRoundValueUsingDecimalRound(decimal value)
    {
        return decimal.Round(value, 2);
    }

    public static decimal GetDecimalRoundValuesUsingMidPointRoundingModelToEven(decimal number)
    {
        return Decimal.Round(number,2, MidpointRounding.ToEven);
    }
    
    public static decimal GetDecimalRoundValuesUsingMidPointRoundingModelAwayFromZero(decimal number)
    {
        return Decimal.Round(number,2, MidpointRounding.AwayFromZero);
    }
    
    public static decimal GetDecimalRoundValuesUsingMidPointRoundingModelToZero(decimal number)
    {
        return Decimal.Round(number,2, MidpointRounding.ToZero);
    }
    
    public static decimal GetDecimalRoundValueUsingDecimalTruncate(decimal value)
    {
        return decimal.Truncate(value);
    }
}