using AsynchronousProgrammingPatterns.Providers;
using AsynchronousProgrammingPatterns.Services.Models;
using System.Text;

namespace Tests;

public class AsynchronousProgrammingPatternsUnitTest
{
    [Fact]
    public void WhenUserFetchedUsingApm_ThenUserReturned()
    {
        var apmUserProvider = new ApmUserProvider();

        apmUserProvider.BeginGetUser(100, callback: (asyncResult) =>
        {
            var context = asyncResult.AsyncState as ApmUserProvider;
            try
            {
                var fileContentBuffer = context?.EndGetUser(asyncResult);

                var fileContent = Encoding.UTF8.GetString(fileContentBuffer!);

                Assert.Contains(fileContent, @"
                Id: 100
                Name: Adam
                ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }, state: apmUserProvider);
    }

    [Fact]
    public void WhenUserFetchedUsingEvent_ThenUserReturned()
    {
        var userProvider = new EapUserProvider();

        userProvider.GetUserAsync(100, null);

        userProvider.GetUserCompleted += (sender, args) =>
        {
            var user = args.UserState as User;
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
