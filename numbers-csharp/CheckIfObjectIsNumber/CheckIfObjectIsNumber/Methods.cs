namespace CheckIfObjectIsNumber;

public static class Methods
{
    public static bool CheckIfIntegerWithEqualityOperator(object value)
        => value.GetType() == typeof(int);

    public static bool CheckIfFloatWithExplicitCast(object value)
    {
        try
        {
            _ = (float)value;

            return true;
        }
        catch (InvalidCastException)
        {
            return false;
        }
    }

    public static bool CheckIfShortUsingConvert(object value)
    {
        try
        {
            _ = Convert.ToInt16(value);

            return true;
        }
        catch (OverflowException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool CheckIfFloatWithIsOperator(object value) => value is float;

    public static bool CheckIfIntWithAsOperator(object value)
    {
        var amount = value as int?;

        return amount is not null;
    }

    public static double CalculateAllTaxesIncludedPrice(object tax)
    {
        var price = 28.0;
        if (tax is double vat)
        {
            price += (price * vat) / 100;
        }

        return price;
    }
}