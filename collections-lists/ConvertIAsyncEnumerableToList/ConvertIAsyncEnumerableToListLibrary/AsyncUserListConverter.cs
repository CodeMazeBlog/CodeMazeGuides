using ConvertIAsyncEnumerableToListLibrary.Model;

namespace ConvertIAsyncEnumerableToListLibrary;
public static class AsyncUserListConverter
{
    public static async Task<List<User>> GetUsersAsListAsync(int delayMilliseconds = 500)
    {
        var usersAsync = UserPageFetcher.GetUsersAsync(delayMilliseconds);

        return await usersAsync.ToListAsync();
    }

    public static async Task<List<User>> GetUsersAsListAsyncWithCancellationToken
    (int delayMilliseconds = 500, CancellationToken cancellationToken = default)
    {
        var usersAsync = UserPageFetcher
            .GetUsersAsyncWithCancellationToken(delayMilliseconds, cancellationToken);

        return await usersAsync.ToListAsync(cancellationToken);
    }
}
