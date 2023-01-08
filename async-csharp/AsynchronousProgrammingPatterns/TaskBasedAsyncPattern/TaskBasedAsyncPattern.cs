using TaskBasedAsyncPattern.Providers;

namespace TaskBasedAsyncPattern;

public static class TaskBasedAsyncPattern
{
    public static async void FetchAndPrintUser(int userId)
    {
        var userProvider = new UserProvider();

        var user = await userProvider.GetUserAsync(userId);

        Console.WriteLine(user.Name);
    }
}
