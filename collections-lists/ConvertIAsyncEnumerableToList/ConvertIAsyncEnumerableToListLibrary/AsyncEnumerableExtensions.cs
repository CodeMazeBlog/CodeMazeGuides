namespace ConvertIAsyncEnumerableToListLibrary;
public static class AsyncEnumerableExtensions
{
    public static async Task<List<T>> ToListAsync<T>
    (this IAsyncEnumerable<T> source, CancellationToken cancellationToken = default)
    {
        var userList = new List<T>();

        await foreach (var item in source
                .ConfigureAwait(false)
                .WithCancellation(cancellationToken))
        {
            userList.Add(item);
        }

        return userList;
    }
}
