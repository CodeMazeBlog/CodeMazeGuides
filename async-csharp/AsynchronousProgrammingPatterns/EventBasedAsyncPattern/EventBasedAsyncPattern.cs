using EventBasedAsyncPattern.Providers;
using Services.Models;

namespace EventBasedAsyncPattern;

public static class EventBasedAsyncPattern
{
    public static void FetchAndPrintUser(int userId)
    {
        var userProvider = new UserProvider();

        // Start asynchronous operation
        userProvider.GetUserAsync(userId, null);

        // If current method is running in UI thread
        // following event handler would be executed in the UI thread
        userProvider.GetUserCompleted += (sender, args) =>
        {
            User? result = args.UserState as User;
            Console.WriteLine(result?.Name);
        };
    }
}
