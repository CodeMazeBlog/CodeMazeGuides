namespace LookupInCSharp;

public record Student(string Name, string Course);

public class LookupOperations
{
    private static readonly List<Student> _students
        = [
            new("Kate Green", "Accounting"),
            new("Dan Sorla", "Economics"),
            new("Luna Delgrino", "Finance")
          ];

    private static readonly List<Student> _duplicateStudents
        = [
            new("Dan Sorla", "Investment Management"),
            new("Dan Sorla", "Economics"),
            new("Luna Delgrino", "Finance")
          ];

    private static readonly ILookup<string, string> _lookup
        = CreateLookupWithKeysAndValues();

    public static ILookup<string, Student> CreateLookupWithKeyOnly()
        => _students.ToLookup(s => s.Name);

    public static ILookup<string, string> CreateLookupWithKeysAndValues()
        => _students.ToLookup(s => s.Name, s => s.Course);

    public static ILookup<string, string> CreateLookupFromListWithDuplicateItem()
        => _duplicateStudents.ToLookup(s => s.Name, s => s.Course);

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