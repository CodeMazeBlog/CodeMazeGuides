namespace ConvertIAsyncEnumerableToListLibrary;
public static class UserListConverterAndChecker
{
    public static async Task ConvertAndCheckUserListTypeAsync()
    {
        var usersAsync = UserPageFetcher.GetUsersAsync();

        var usersList = await usersAsync.ToListAsync();

        Console.WriteLine(usersList.GetType());
    }
}
