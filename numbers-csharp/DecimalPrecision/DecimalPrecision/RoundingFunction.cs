namespace DecimalPrecision;

public class RoundingFunction
{
    public decimal GetDecimalRoundValueUsingMathRound(decimal value)
    {
        decimal roundedValue = Math.Round(value, 2);

        return roundedValue;
    }
    
    public decimal GetDecimalRoundValueUsingDecimalRound(decimal value)
    {
        decimal roundedValue = decimal.Round(value, 2, MidpointRounding.AwayFromZero);

        return roundedValue;
    }
    
    public decimal GetDecimalRoundValueUsingDecimalTruncate(decimal value)
    {
        decimal truncatedValue = decimal.Truncate(value);

        return truncatedValue;
    }
}