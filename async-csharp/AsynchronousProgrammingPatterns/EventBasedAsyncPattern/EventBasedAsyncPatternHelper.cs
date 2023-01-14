using EventBasedAsyncPattern.Providers;
using Services.Models;

namespace EventBasedAsyncPattern;

public static class EventBasedAsyncPatternHelper
{
    public static void FetchAndPrintUser(int userId)
    {
        var userProvider = new UserProvider();

        userProvider.GetUserCompleted += (sender, args) =>
        {
            var result = args.UserState as User;
            Console.WriteLine($"Id: {result?.Id}\nName: {result?.Name}");
        };

        userProvider.GetUserAsync(userId, null);
    }
}
