using System;
using ExampleApp.Helpers;
using System.Collections.Concurrent;

namespace ExampleApp.DictionaryExamples;

public class RoleManagerConcurrentDictionary
{
    private readonly ConcurrentDictionary<string, User> _record;

    public RoleManagerConcurrentDictionary()
    {
        _record = new();
    }

    public async Task<bool> TryAssign(string key, int userId)
    {
        var user = await UserProvider.GetUser(userId);

        return _record.TryAdd(key, user);
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

