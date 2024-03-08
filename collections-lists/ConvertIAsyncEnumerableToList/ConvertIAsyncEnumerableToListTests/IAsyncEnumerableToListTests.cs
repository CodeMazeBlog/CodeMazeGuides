namespace ConvertIAsyncEnumerableToListTests;

public class IAsyncEnumerableToListTests
{
    [Fact]
    public async Task GivenGetUsersAsListAsync_WhenCalled_ThenReturnsListOfUsers()
    {
        // Act
        var usersList = await AsyncUserListConverter
            .GetUsersAsListAsync(10);

        // Assert
        Assert.NotNull(usersList);
        Assert.Equal(9, usersList.Count);
    }

    [Fact]
    public async Task GivenGetUsersAsListAsyncWithCancellationToken_WhenNotCancelled_ThenReturnsListOfUsers()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;

        // Act
        var usersList = await AsyncUserListConverter
            .GetUsersAsListAsyncWithCancellationToken(10, cancellationToken);

        // Assert
        Assert.NotNull(usersList);
        Assert.Equal(9, usersList.Count);
    }

    [Fact]
    public async Task GivenGetUsersAsListAsyncWithCancellationToken_WhenCancelled_ThenThrowsOperationCanceledException()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        cancellationTokenSource.Cancel();

        // Act
        await Assert.ThrowsAsync<OperationCanceledException>(() =>
            AsyncUserListConverter
            .GetUsersAsListAsyncWithCancellationToken(10, cancellationToken));
    }
}