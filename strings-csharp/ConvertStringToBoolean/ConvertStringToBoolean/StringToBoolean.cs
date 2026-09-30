namespace ConvertStringToBoolean;

public static class StringToBoolean
{
    public static void ToBooleanMethod()
    {
        string?[] validString = { null, "true", "True", "    true   ", "false", "False", "    false" };

        string[] invalidString = { "", string.Empty, "t", "    yes   ", "-1", "0", "1" };

        var values = validString.Concat(invalidString);

        foreach (var value in values)
        {
            try
            {
                Console.WriteLine($"Converted '{value}' to {Convert.ToBoolean(value)}.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to convert '{value}' to a Boolean.\n");
            }
        }
    }

    public static void ParseMethod()
    {
        string[] validString = { "true", "True", "    true   ", "false", "False", "    false" };

        string?[] invalidString = { null, "", string.Empty, "t", "    yes   ", "-1", "0", "1" };

        var values = validString.Concat(invalidString);

        foreach (var value in values)
        {
            try
            {
                Console.WriteLine($"Converted '{value}' to {bool.Parse(value!)}.\n");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Unable to convert null to a Boolean.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to convert '{value}' to a Boolean.\n");
            }
        }
    }

    public static void TryParseMethod()
    {
        string[] validString = { "true", "True", "    true   ", "false", "False", "    false" };

        string?[] invalidString = { null, "", string.Empty, "t", "    yes   ", "-1", "0", "1" };

        var values = validString.Concat(invalidString);

        foreach (var value in values)
        {
            if (bool.TryParse(value, out bool booleanValue))
            {
                Console.WriteLine($"Conversion successful: '{value}' to {booleanValue}.\n");
            }
            else
            {
                Console.WriteLine($"Conversion Failed: '{value}' to {booleanValue}.\n");
            }
        }
    }

    public static bool? ToBoolOrNull(string? value) => value?.Trim().ToLowerInvariant() switch
    {
        "true" or "yes" or "y" or "1" or "on" => true,
        "false" or "no" or "n" or "0" or "off" => false,
        _ => null
    };
}
