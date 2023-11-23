namespace ConversionsInCSharp;

public static class Utilities
{
    // basic examples
    public static void ConvertIntToOtherTypes(int value)
    {
        double intToDouble = Convert.ToDouble(value);
        bool intToBool = Convert.ToBoolean(value);
        string intToString = Convert.ToString(value);

        string intToDoubleText = $"{value} ({value.GetType()}) -> {intToDouble} ({intToDouble.GetType()})";
        string intToBoolText = $"{value} ({value.GetType()}) -> {intToBool} ({intToBool.GetType()})";
        string intToStringText = $"{value} ({value.GetType()}) -> {intToString} ({intToString.GetType()})";

        string output = $"{intToDoubleText}\n{intToBoolText}\n{intToStringText}";

        Console.WriteLine(output);        
    }

    // convenience method to test conversions
    public static void MakeConversion<T1, T2>(Func<T1, T2> convert, T1 value)
    {
        try
        {
            T2 result = convert(value);
            Console.WriteLine($"{value} ({value?.GetType()}) -> {result} ({result?.GetType()})");

            if (value?.GetType() == result?.GetType() )
            {
                Console.WriteLine("No conversion, same types");
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }        
    }  

    public static void ConvertToStringWithBase(int number, int baseValue)
    {
        try
        {
            string numberRepresentation = Convert.ToString(number, baseValue);
            Console.WriteLine($"{number} (in base 10) -> {numberRepresentation} (in base {baseValue})");
        }
        catch 
        {
            Console.WriteLine("Wrong base (must be 2, 8, 10 or 16)");
        }
    }

    public static void ConvertFromStringWithBase(string numberRepresentation, int baseValue)
    {
        try
        {
            int number = Convert.ToInt32(numberRepresentation, baseValue);
            Console.WriteLine($"{numberRepresentation} (in base {baseValue}) -> {number} (in base 10)");
        }
        catch
        {
            Console.WriteLine("Wrong base (must be 2, 8, 10 or 16)");
        }
    }
}
