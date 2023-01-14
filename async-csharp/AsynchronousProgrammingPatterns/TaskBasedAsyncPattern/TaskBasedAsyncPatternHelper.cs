using TaskBasedAsyncPattern.Providers;

namespace TaskBasedAsyncPattern;

public static class TaskBasedAsyncPatternHelper
{
    public static async Task FetchAndPrintUser(int userId)
    {
        var userProvider = new UserProvider();

        var user = await userProvider.GetUserAsync(userId);

        Console.WriteLine($"Id: {user.Id}\nName: {user.Name}");
    }
}
