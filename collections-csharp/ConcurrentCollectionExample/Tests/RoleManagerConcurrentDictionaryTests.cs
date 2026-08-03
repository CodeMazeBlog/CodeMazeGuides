using System;
using ExampleApp.DictionaryExamples;
using ExampleApp.Helpers;

namespace Tests;

public class RoleManagerConcurrentDictionaryTests
{
    [Fact]
    public async Task GivenIdenticalRoles_WhenTryAssignIsInvokedConcurrently_ThenOnlyOneUserIsAssigned()
    {
        var role = "Admin";
        var concurrentRoleManager = new RoleManagerConcurrentDictionary();
        var task1 = concurrentRoleManager.TryAssign(role, 1);
        var task2 = concurrentRoleManager.TryAssign(role, 2);
        var task3 = concurrentRoleManager.TryAssign(role, 3);

        await Task.WhenAll(task1, task2, task3);
        var roles = concurrentRoleManager.GetAll();
        var valueExists = roles.TryGetValue(role, out User? user);

        Assert.True(valueExists);
        Assert.NotNull(user);
    }

    [Fact]
    public async Task GivenDifferentRoles_WhenTryAssignIsInvokedConcurrently_ThenAllUserAreAssigned()
    {
        var role = "Admin";
        var role1 = "Dev";
        var role2 = "User";
        var concurrentRoleManager = new RoleManagerConcurrentDictionary();
        var task1 = concurrentRoleManager.TryAssign(role, 1);
        var task2 = concurrentRoleManager.TryAssign(role1, 2);
        var task3 = concurrentRoleManager.TryAssign(role2, 3);

        await Task.WhenAll(task1, task2, task3);
        var roles = concurrentRoleManager.GetAll();
        var firstRoleExits = roles.TryGetValue(role, out User? user);
        var secondRoleExits = roles.TryGetValue(role, out User? user1);
        var thirdRoleExits = roles.TryGetValue(role, out User? user2);

        Assert.True(firstRoleExits);
        Assert.True(secondRoleExits);
        Assert.True(thirdRoleExits);

        Assert.NotNull(user);
        Assert.NotNull(user1);
        Assert.NotNull(user2);
    }
}

