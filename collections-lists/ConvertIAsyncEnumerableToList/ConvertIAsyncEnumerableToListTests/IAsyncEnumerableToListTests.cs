namespace ConvertIAsyncEnumerableToListTests;

public class IAsyncEnumerableToListTests
{
    private static readonly CancellationToken CancellationToken = new CancellationToken();
    private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

    [Fact]
    public async Task GivenGetUsersAsListAsync_WhenCalled_ThenReturnsListOfUsers()
    {
        // Act
        var usersList = await AsyncUserListConverter
            .GetUsersAsListAsync();

        // Assert
        Assert.NotNull(usersList);
        Assert.Equal(9, usersList.Count);
    }

    [Fact]
    public async Task GivenGetUsersAsListAsyncWithCancellationToken_WhenNotCancelled_ThenReturnsListOfUsers()
    {
        // Act
        var usersList = await AsyncUserListConverter
            .GetUsersAsListAsyncWithCancellationToken(CancellationToken);

        // Assert
        Assert.NotNull(usersList);
        Assert.Equal(9, usersList.Count);
    }

    [Fact]
    public async Task GivenGetUsersAsListAsyncWithCancellationToken_WhenCancelled_ThenThrowsOperationCanceledException()
    {
        // Arrange
        CancellationTokenSource.Cancel();

        // Act
        await Assert.ThrowsAsync<OperationCanceledException>(() =>
            AsyncUserListConverter
            .GetUsersAsListAsyncWithCancellationToken(CancellationTokenSource.Token));
    }

    [Fact]
    public async Task GivenIAsyncEnumerable_WhenToListAsyncCalledWithoutCancellationToken_ThenReturnsListOfItems()
    {
        // Arrange
        var expectedItems = new List<int> { 1, 2, 3 };
        var asyncEnumerable = expectedItems.ToAsyncEnumerable();

        // Act
        var list = await ConvertIAsyncEnumerableToListLibrary
            .AsyncEnumerableExtensions
            .ToListAsync(asyncEnumerable);

        // Assert
        Assert.NotNull(list);
        Assert.Equal(expectedItems.Count, list.Count);
        Assert.Equal(expectedItems, list);
    }


    [Fact]
    public async Task GivenIAsyncEnumerable_WhenToListAsyncCalledWithTriggeredCancellationToken_ThenThrowsOperationCanceledException()
    {
        // Arrange
        var asyncEnumerable = new List<int> { 1, 2, 3 }
        .ToAsyncEnumerable();

        CancellationTokenSource.Cancel();

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(() =>
            ConvertIAsyncEnumerableToListLibrary
            .AsyncEnumerableExtensions
            .ToListAsync(asyncEnumerable, CancellationTokenSource.Token));
    }
}