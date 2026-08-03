using AsynchronousProgrammingPatterns.Providers;

namespace AsynchronousProgrammingPatterns;

public static class TaskBasedAsyncPatternHelper
{
    public static async Task FetchAndPrintUser(int userId)
    {
        var tapUserProvider = new TapUserProvider();

        var user = await tapUserProvider.GetUserAsync(userId);

        Console.WriteLine($"Id: {user.Id}\nName: {user.Name}");
    }
}
