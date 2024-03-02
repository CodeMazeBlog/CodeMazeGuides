using ConvertIAsyncEnumerableToListLibrary.Model;

namespace ConvertIAsyncEnumerableToListLibrary;
public static class AsyncUserListConverter
{
    public static async Task<List<User>> GetUsersAsListAsync()
    {
        var usersAsync = UserPageFetcher.GetUsersAsync();

        return await usersAsync.ToListAsync();
    }

    public static async Task<List<User>> GetUsersAsListAsyncWithCancellationToken
    (CancellationToken cancellationToken = default)
    {
        var usersAsync = UserPageFetcher
            .GetUsersAsyncWithCancellationToken(cancellationToken: cancellationToken);

        return await usersAsync.ToListAsync(cancellationToken);
    }
}
