namespace ToDictionaryMethodInCSharp;

public class ToDictionaryOperations
{
    private static readonly List<Country> _countries
        = [
            new("Egypt", "Cairo", "Africa"),
            new("India", "New Delhi", "Asia"),
            new("Chile", "Santiago", "South America"),
            new("Australia", "Canberra", "Oceania")
          ];

    public static Dictionary<string, Country> CallToDictionaryWithKeysOnly()
        => _countries.ToDictionary(c => c.Name);

    public static Dictionary<string, string> CallToDictionaryWithKeysAndValues()
        => _countries.ToDictionary(c => c.Name, c => c.Capital);
}