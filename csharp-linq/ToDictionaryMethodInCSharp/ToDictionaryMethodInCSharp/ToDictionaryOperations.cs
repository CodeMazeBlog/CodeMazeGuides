namespace ToDictionaryMethodInCSharp;

public class ToDictionaryOperations
{
    private static readonly List<Country> _countries
        = [
            new("Egypt", "Cairo", "Africa"),
            new("India", "New Delhi", "Asia"),
            new("Chile", "Santiago", "South America"),
            new("Australia", "Canberra", "Oceania"),
            new("Kenya", "Nairobi", "Africa")
          ];

    public static Dictionary<string, Country> CallToDictionaryWithKeysOnly()
        => _countries.ToDictionary(c => c.Name);

    public static Dictionary<string, string> CallToDictionaryWithKeysAndValues()
        => _countries.ToDictionary(c => c.Name, c => c.Capital);

    public static Dictionary<string, string> CallToDictionaryOnKeyValuePairs()
        => _countries
            .Select(c => new KeyValuePair<string, string>(c.Name, c.Capital))
            .ToDictionary();

    public static Dictionary<string, string> CallToDictionaryOnTuples()
        => _countries
            .Select(c => (c.Name, c.Capital))
            .ToDictionary();

    public static Dictionary<string, Country> CallToDictionaryWithComparer()
        => _countries.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);

    // Throws: two countries share the continent "Africa"
    public static Dictionary<string, Country> CallToDictionaryWithDuplicateKeys()
        => _countries.ToDictionary(c => c.Continent);

    public static Dictionary<string, Country> CallToDictionaryKeepingFirstPerContinent()
        => _countries
            .DistinctBy(c => c.Continent)
            .ToDictionary(c => c.Continent);

    public static ILookup<string, Country> CallToLookupOnContinents()
        => _countries.ToLookup(c => c.Continent);
}