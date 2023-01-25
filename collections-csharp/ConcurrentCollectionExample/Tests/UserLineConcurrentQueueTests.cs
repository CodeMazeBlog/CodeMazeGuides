using System;
using ExampleApp.ConcurrentQueueExamples;
using ExampleApp.Helpers;

namespace Tests;

public class UserLineConcurrentQueueTests
{
    [Fact]
    public async Task GivenUserIds_WhenAddUserIsInvokedConcurrently_ThenUsersAreAdded()
    {
        var userline = new UserLineConcurrentQueue();
        var task1 = Task.Run(() => userline.AddUser(1));
        var task2 = Task.Run(() => userline.AddUser(2));
        var task3 = Task.Run(() => userline.AddUser(3));

        await Task.WhenAll(task1, task2, task3);

        Assert.Equal(3, userline.CountUsersInLine());
    }

    [Fact]
    public async Task GivenUserId_WhenTryServeUserIsInvoked_ThenUserIsServedAndRemovedFromLine()
    {
        var userId = 1;
        var userLine = new UserLineConcurrentQueue();
        await userLine.AddUser(userId);
        var result = userLine.TryServeUser(out User? user);

        Assert.True(result);
        Assert.Equal(userId, user?.Id);
        Assert.Equal(0, userLine.CountUsersInLine());
    }

    [Fact]
    public async Task GivenUserIds_WhenLookWhoIsFirstIsInvoked_ThenUserIsRetrieved()
    {
        var userId = 1;
        var userLine = new UserLineConcurrentQueue();
        await userLine.AddUser(userId);
        var user = userLine.LookWhoIsFirst();

        Assert.NotNull(user);
        Assert.Equal(userId, user?.Id);
        Assert.Equal(1, userLine.CountUsersInLine());
    }
}

