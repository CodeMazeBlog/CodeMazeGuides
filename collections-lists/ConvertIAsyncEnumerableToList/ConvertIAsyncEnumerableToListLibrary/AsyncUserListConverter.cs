using ConvertIAsyncEnumerableToListLibrary.Model;

namespace ConvertIAsyncEnumerableToListLibrary;
public static class AsyncUserListConverter
{
    public static async Task<List<User>> GetUsersAsListAsync()
    {
        var usersAsync = UserPageFetcher.GetUsersAsync();

        var usersList = await usersAsync.ToListAsync();

        return usersList;
    }

    public static async Task<List<User>> GetUsersAsListAsyncWithCancellationToken
    (CancellationToken cancellationToken = default)
    {
        var usersAsync = UserPageFetcher.GetUsersAsyncWithCancellationToken(cancellationToken);

        var usersList = await usersAsync.ToListAsync();

        return usersList;
    }
}
