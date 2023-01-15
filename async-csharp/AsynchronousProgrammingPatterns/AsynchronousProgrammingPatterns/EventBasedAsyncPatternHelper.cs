using AsynchronousProgrammingPatterns.Providers;
using AsynchronousProgrammingPatterns.Services.Models;

namespace AsynchronousProgrammingPatterns;

public static class EventBasedAsyncPatternHelper
{
    public static void FetchAndPrintUser(int userId)
    {
        var eapUserProvider = new EapUserProvider();

        eapUserProvider.GetUserCompleted += (sender, args) =>
        {
            var result = args.UserState as User;
            Console.WriteLine($"Id: {result?.Id}\nName: {result?.Name}");
        };

        eapUserProvider.GetUserAsync(userId, null);
    }
}
