namespace LookupInCSharp;

public class LookupOperations
{
    private static readonly ILookup<string, string> _lookup
        = CreateLookup();

    public static ILookup<string, string> CreateLookup()
    {
        List<Student> students
            = [
                new("Dan Sorla", "Accounting"),
                new("Dan Sorla", "Economics"),
                new("Luna Delgrino", "Finance"),
                new("Kate Green", "Investment Management")
              ];

        return students.ToLookup(s => s.Name, s => s.Course);
    }

    public static IEnumerable<string> RetrieveValuesOfAKeyFromLookup(string key)
        => _lookup[key];

    public static List<string> RetrieveAllKeysFromLookup()
    {
        List<string> keys = [];
        foreach (var studentGroup in _lookup)
        {
            keys.Add(studentGroup.Key);
        }

        return keys;
    }

    public static IEnumerable<string> RetrieveAllValuesFromLookup()
    {
        List<string> values = [];
        foreach (var studentGroup in _lookup)
        {
            foreach (var str in studentGroup)
            {
                values.Add(str);
            }
        }

        return values;
    }

    public static bool SearchForKeyInLookup(string key)
        => _lookup.Contains(key);

    public static int GetLookupCount()
        => _lookup.Count;
}