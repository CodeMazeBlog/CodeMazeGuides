using ConvertIAsyncEnumerableToListLibrary.Model;
using System.Runtime.CompilerServices;

namespace ConvertIAsyncEnumerableToListLibrary;
public static class UserPageFetcher
{
    public static async IAsyncEnumerable<User> GetUsersAsync()
    {
        for (int page = 1; page <= 3; page++)
        {
            await Task.Delay(500);

            var users = new List<User>
            {
                new User { Id = 1, Name = "Alice" },
                new User { Id = 2, Name = "Bob" },
                new User { Id = 3, Name = "John" },
            };

            foreach (var user in users)
            {
                yield return user;
            }
        }
    }

    public static async IAsyncEnumerable<User> GetUsersAsyncWithCancellationToken
    ([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        for (int page = 1; page <= 3; page++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await Task.Delay(500, cancellationToken);

            var users = new List<User>
            {
                new User { Id = 1, Name = "Alice" },
                new User { Id = 2, Name = "Bob" },
                new User { Id = 3, Name = "John" },
            };

            foreach (var user in users)
            {
                yield return user;
            }
        }
    }
}
