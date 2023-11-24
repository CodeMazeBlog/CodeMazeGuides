using AsynchronousProgrammingPatterns.Providers;

namespace Tests;

public class AsynchronousProgrammingPatternsUnitTest
{
    [Fact]
    public void WhenUserFetchedUsingEvent_ThenUserReturned()
    {
        var userProvider = new EapUserProvider();

        userProvider.GetUserAsync(100, null);

        userProvider.GetUserCompleted += (sender, args) =>
        {
            var user = args.Result;
            Assert.NotNull(user);
            Assert.Equal(100, user.Id);
            Assert.Equal("Adam", user.Name);
        };
    }

    [Fact]
    public async Task WhenUserFetchedUsingTask_ThenUserReturned()
    {
        var userProvider = new TapUserProvider();

        var user = await userProvider.GetUserAsync(100);

        Assert.NotNull(user);
        Assert.Equal(100, user.Id);
        Assert.Equal("Adam", user.Name);
    }
}
