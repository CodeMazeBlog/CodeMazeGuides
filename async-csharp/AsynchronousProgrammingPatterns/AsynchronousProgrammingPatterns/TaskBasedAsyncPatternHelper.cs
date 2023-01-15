using AsynchronousProgrammingPatterns.Providers;
using System.IO;
using System.Text;

namespace AsynchronousProgrammingPatterns;

public static class TaskBasedAsyncPatternHelper
{
    public static async Task FetchAndPrintUser(int userId)
    {
        var userProvider = new TapUserProvider();

        var user = await userProvider.GetUserAsync(userId);

        Console.WriteLine($"Id: {user.Id}\nName: {user.Name}");
    }
}
