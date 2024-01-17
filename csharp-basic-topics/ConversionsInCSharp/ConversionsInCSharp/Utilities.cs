namespace ConversionsInCSharp;

public static class Utilities
{
    public static string ConvertIntToOtherTypes(int value)
    {
        var intToDouble = Convert.ToDouble(value);
        var intToBool = Convert.ToBoolean(value);
        var intToString = Convert.ToString(value);

        var intToDoubleText = $"{value} ({value.GetType()}) -> {intToDouble} ({intToDouble.GetType()})";
        var intToBoolText = $"{value} ({value.GetType()}) -> {intToBool} ({intToBool.GetType()})";
        var intToStringText = $"{value} ({value.GetType()}) -> {intToString} ({intToString.GetType()})";

        var output = $"{intToDoubleText}\n{intToBoolText}\n{intToStringText}";

        return output;
    }
       
    public static string MakeConversion<T1, T2>(Func<T1, T2> convert, T1 value)
    {
        try
        {
            T2 result = convert(value);

            var output = $"{value} ({value?.GetType()}) -> {result} ({result?.GetType()})";

            if (value?.GetType() == result?.GetType())
            {
                output += "\nNo conversion, same types";
            }

            return output;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static string ConvertToStringWithBase(int number, int baseValue)
    {
        try
        {
            var numberRepresentation = Convert.ToString(number, baseValue);
            return $"{number} (in base 10) -> {numberRepresentation} (in base {baseValue})";
        }
        catch
        {
            return "Wrong base (must be 2, 8, 10 or 16)";
        }
    }

    public static string ConvertFromStringWithBase(string numberRepresentation, int baseValue)
    {
        try
        {
            var number = Convert.ToInt32(numberRepresentation, baseValue);
            return $"{numberRepresentation} (in base {baseValue}) -> {number} (in base 10)";
        }
        catch
        {
            return "Wrong base (must be 2, 8, 10 or 16)";
        }
    }
}
