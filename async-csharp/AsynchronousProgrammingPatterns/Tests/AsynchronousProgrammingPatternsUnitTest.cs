using Services.Models;

namespace Tests;

public class AsynchronousProgrammingPatternsUnitTest
{
    [Fact]
    public void WhenUserFetchedUsingEvent_ThenUserReturned()
    {
        var userProvider = new EventBasedAsyncPattern.Providers.UserProvider();

        userProvider.GetUserAsync(100, null);

        userProvider.GetUserCompleted += (sender, args) =>
        {
            User? user = args.UserState as User;
            Assert.NotNull(user);
            Assert.Equal(100, user.Id);
            Assert.Equal("Adam", user.Name);
        };
    }

    [Fact]
    public async Task WhenUserFetchedUsingTask_ThenUserReturned()
    {
        var userProvider = new TaskBasedAsyncPattern.Providers.UserProvider();

        var user = await userProvider.GetUserAsync(100);

        Assert.NotNull(user);
        Assert.Equal(100, user.Id);
        Assert.Equal("Adam", user.Name);
    }
}
