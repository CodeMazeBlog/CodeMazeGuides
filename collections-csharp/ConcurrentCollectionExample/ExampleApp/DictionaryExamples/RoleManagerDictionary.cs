using ExampleApp.Helpers;

namespace ExampleApp.DictionaryExamples;

public class RoleManagerDictionary
{
    private readonly Dictionary<string, User> _record;

    public RoleManagerDictionary()
    {
        _record = new();
    }

    public async Task<bool> TryAssign(string role, int userId)
    {
        var user = await UserProvider.GetUser(userId);

        return _record.TryAdd(role, user);
    }

    public IDictionary<string, User> GetAll()
    {
        return _record;
    }

    public void PrintAll()
    {
        Console.WriteLine($"No. of Records: {_record.Count()}");
        foreach (var (role, user) in _record)
        {
            Console.WriteLine($"Role: {role}, User: {user}");
        }
    }
}