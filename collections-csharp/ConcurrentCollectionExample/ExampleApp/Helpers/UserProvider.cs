using System.Collections.Concurrent;

namespace ExampleApp.Helpers;

public record User(int Id, string FirstName, string LastName);

public class UserProvider
{
    private static readonly ConcurrentDictionary<int,User> _users = new()
    {
        [1] = new(1,"John", "Doe"),
        [2] = new(2,"Alen", "T"),
        [3] = new(3,"Alice", "Martin"),
        [4] = new(4,"Julia", "Walker")
    };

    public static async Task<User> GetUser(int id)
    {
        await Task.Delay((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
        
        return _users[id];
    }   
}
