namespace LookupInCSharp;

public class LookupOperations
{
    private static readonly List<Student> _students
        = [
            new("Dan Sorla", "Accounting"),
            new("Dan Sorla", "Economics"),
            new("Luna Delgrino", "Finance"),
            new("Kate Green", "Investment Management")
          ];

    private static readonly ILookup<string, string> _lookup
        = CreateLookup();

    public static ILookup<string, string> CreateLookup()
        => _students.ToLookup(s => s.Name, s => s.Course);

    public static IEnumerable<string> RetrieveValuesOfAKeyFromLookup(string key)
        => _lookup[key];

    public static List<string> RetrieveAllKeysFromLookup() 
        => _lookup.Select(studentGroup => studentGroup.Key).ToList();

    public static IEnumerable<string> RetrieveAllValuesFromLookup()
        => _lookup.SelectMany(studentGroup => studentGroup);

    public static bool SearchForKeyInLookup(string key)
        => _lookup.Contains(key);

    public static int GetLookupCount()
        => _lookup.Count;
}