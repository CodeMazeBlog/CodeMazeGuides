namespace AuthorizationPolicyProviders.Tests;

public class MinimumLoyaltyPointsRequirementHandlerTests
{
    private static readonly MinimumLoyaltyPointsRequirementHandler _testHandler = new();

    [Fact]
    public async Task WhenPointsMoreThanMinimum_ThenPolicyIsSucceeded()
    {
        var requirement = new MinimumLoyaltyPointsRequirement(minimumLoyaltyPoints: 1);
        var user = new ClaimsPrincipal([new ClaimsIdentity([new Claim(ClaimTypeConstants.LoyaltyPoints, 2.ToString())])]);

        var context = new AuthorizationHandlerContext([requirement], user, resource: null);

        await _testHandler.HandleAsync(context);

        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenPointsEqualToMinimum_ThenPolicyIsSucceeded()
    {
        var requirement = new MinimumLoyaltyPointsRequirement(minimumLoyaltyPoints: 1);
        var user = new ClaimsPrincipal([new ClaimsIdentity([new Claim(ClaimTypeConstants.LoyaltyPoints, 1.ToString())])]);

        var context = new AuthorizationHandlerContext([requirement], user, resource: null);

        await _testHandler.HandleAsync(context);

        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenPointsLessThanMinimum_ThenPolicyIsNotSucceeded()
    {
        var requirement = new MinimumLoyaltyPointsRequirement(minimumLoyaltyPoints: 1);
        var user = new ClaimsPrincipal([new ClaimsIdentity([new Claim(ClaimTypeConstants.LoyaltyPoints, 0.ToString())])]);

        var context = new AuthorizationHandlerContext([requirement], user, resource: null);

        await _testHandler.HandleAsync(context);

        Assert.False(context.HasSucceeded);
    }
}
