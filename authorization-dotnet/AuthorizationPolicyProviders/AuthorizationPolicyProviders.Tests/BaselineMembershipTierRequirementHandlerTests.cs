using System.Security.Claims;
using AuthorizationPolicyProviders.Authorization.Handlers;
using AuthorizationPolicyProviders.Authorization.Requirements;
using AuthorizationPolicyProviders.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Tests;

public class BaselineMembershipTierRequirementHandlerTests
{
    private static BaselineMembershipTierRequirementHandler _testHandler = new();

    [Fact]
    public async Task WhenTierAboveBaseline_ThenPolicyIsSucceeded()
    {
        var requirement = new BaselineMembershipTierRequirement(baselineMembershipTier: MembershipTier.Silver);
        var user = new ClaimsPrincipal([new ClaimsIdentity([new Claim("MembershipTier", MembershipTier.Gold.ToString())])]);

        var context = new AuthorizationHandlerContext([requirement], user, resource: null);

        await _testHandler.HandleAsync(context);

        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenTierEqualToBaseline_ThenPolicyIsSucceeded()
    {
        var requirement = new BaselineMembershipTierRequirement(baselineMembershipTier: MembershipTier.Silver);
        var user = new ClaimsPrincipal([new ClaimsIdentity([new Claim("MembershipTier", MembershipTier.Silver.ToString())])]);

        var context = new AuthorizationHandlerContext([requirement], user, resource: null);

        await _testHandler.HandleAsync(context);

        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenTierBelowBaseline_ThenPolicyIsNotSucceeded()
    {
        var requirement = new BaselineMembershipTierRequirement(baselineMembershipTier: MembershipTier.Silver);
        var user = new ClaimsPrincipal([new ClaimsIdentity([new Claim("MembershipTier", MembershipTier.Standard.ToString())])]);

        var context = new AuthorizationHandlerContext([requirement], user, resource: null);

        await _testHandler.HandleAsync(context);

        Assert.False(context.HasSucceeded);
    }
}
