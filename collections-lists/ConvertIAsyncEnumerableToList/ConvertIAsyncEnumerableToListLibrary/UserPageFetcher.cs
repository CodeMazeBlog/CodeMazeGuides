using ConvertIAsyncEnumerableToListLibrary.Model;
using System.Runtime.CompilerServices;

namespace ConvertIAsyncEnumerableToListLibrary;
public static class UserPageFetcher
{
    public static async IAsyncEnumerable<User> GetUsersAsync(int delayMilliseconds = 500)
    {
        for (int page = 1; page <= 3; page++)
        {
            await Task.Delay(delayMilliseconds);

            var users = new List<User>
            {
                new User((page - 1) * 3 + 1, "Alice"),
                new User((page - 1) * 3 + 2, "Bob"),
                new User((page - 1) * 3 + 3, "John")
            };

            foreach (var user in users)
            {
                yield return user;
            }
        }
    }

    public static async IAsyncEnumerable<User> GetUsersAsyncWithCancellationToken
    (int delayMilliseconds = 500, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int page = 1; page <= 3; page++)
        {
            await Task.Delay(delayMilliseconds, cancellationToken);

            var users = new List<User>
            {
                new User((page - 1) * 3 + 1, "Alice"),
                new User((page - 1) * 3 + 2, "Bob"),
                new User((page - 1) * 3 + 3, "John")
            };

            foreach (var user in users)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return user;
            }
        }
    }
}
