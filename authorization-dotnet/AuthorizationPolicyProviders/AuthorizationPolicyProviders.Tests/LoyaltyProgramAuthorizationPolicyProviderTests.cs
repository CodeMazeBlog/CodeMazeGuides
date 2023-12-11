using AuthorizationPolicyProviders.Authorization.PolicyProviders;
using AuthorizationPolicyProviders.Authorization.Requirements;
using AuthorizationPolicyProviders.Data.Repositories;
using AuthorizationPolicyProviders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace AuthorizationPolicyProviders.Tests;

public class LoyaltyProgramAuthorizationPolicyProviderTests
{
    private class TestAuthorizationRequirement : IAuthorizationRequirement { }

    private static AuthorizationPolicy _testAuthorizationPolicy =
        new(
            new List<IAuthorizationRequirement>() { new TestAuthorizationRequirement() },
            new List<string>() { string.Empty }
        );

    private const string TestAuthorizationPolicyName = "Test";

    private IOptions<AuthorizationOptions> TestAuthorizationOptions { get; }

    private LoyaltyProgramAuthorizationPolicyProvider TestPolicyProvider { get; }

    public LoyaltyProgramAuthorizationPolicyProviderTests()
    {
        var authorizationOptions = new AuthorizationOptions();
        authorizationOptions.AddPolicy(TestAuthorizationPolicyName, _testAuthorizationPolicy);

        TestAuthorizationOptions = Options.Create(authorizationOptions);

        TestPolicyProvider = new(new SampleLoyaltyRequirementsRepository(), TestAuthorizationOptions);
    }

    [Fact]
    public async Task WhenPolicyNameDoesNotStartWithPrefix_ThenBackupProviderUsedForNameLookup()
    {
        const string policyName = "Test";

        var providedPolicy = await TestPolicyProvider.GetPolicyAsync(policyName);

        Assert.Equal(_testAuthorizationPolicy, providedPolicy);
    }

    [Fact]
    public async Task WhenRequirementsNotReturnedByRepository_ThenNoPolicyReturned()
    {
        const string policyName = "Loyalty:Test";

        var providedPolicy = await TestPolicyProvider.GetPolicyAsync(policyName);

        Assert.Null(providedPolicy);
    }

    [Fact]
    public async Task WhenRequirementsReturnedByRepository_ThenAppropriateAuthorizationPolicyReturned()
    {
        const string policyName = "Loyalty:PriorityCheckIn";
        const MembershipTier baselineMembershipTier = MembershipTier.Silver;
        const int minimumLoyaltyPoints = 100;

        var providedPolicy = await TestPolicyProvider.GetPolicyAsync(policyName);

        Assert.NotNull(providedPolicy);
        Assert.Contains(providedPolicy.Requirements, r =>
            r is BaselineMembershipTierRequirement { BaselineMembershipTier: baselineMembershipTier });
        Assert.Contains(providedPolicy.Requirements, r =>
            r is MinimumLoyaltyPointsRequirement { MinimumLoyaltyPoints: minimumLoyaltyPoints });
    }
}