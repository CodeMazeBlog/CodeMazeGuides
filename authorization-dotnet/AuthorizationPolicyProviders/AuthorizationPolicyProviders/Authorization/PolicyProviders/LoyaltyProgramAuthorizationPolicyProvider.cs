using AuthorizationPolicyProviders.Authorization.Requirements;
using AuthorizationPolicyProviders.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace AuthorizationPolicyProviders.Authorization.PolicyProviders;

public class LoyaltyProgramAuthorizationPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly ILoyaltyRequirementsRepository _loyaltyRequirementsRepository;
    private readonly IAuthorizationPolicyProvider _backupAuthorizationPolicyProvider;

    public LoyaltyProgramAuthorizationPolicyProvider(
        ILoyaltyRequirementsRepository loyaltyRequirementsRepository,
        IOptions<AuthorizationOptions> authorizationOptions
    )
    {
        _loyaltyRequirementsRepository = loyaltyRequirementsRepository;
        _backupAuthorizationPolicyProvider = new DefaultAuthorizationPolicyProvider(authorizationOptions);
    }

    public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!policyName.StartsWith(AuthorizationConstants.LoyaltyPolicyPrefix))
            return await _backupAuthorizationPolicyProvider.GetPolicyAsync(policyName);

        var actionName = policyName[AuthorizationConstants.LoyaltyPolicyPrefix.Length..];

        var requirements = await _loyaltyRequirementsRepository.GetByActionNameAsync(actionName);

        if (requirements is null) return null;

        var policyBuilder = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);

        policyBuilder.AddRequirements(new BaselineMembershipTierRequirement(requirements.BaselineMembershipTier));
        policyBuilder.AddRequirements(new MinimumLoyaltyPointsRequirement(requirements.MinimumLoyaltyPoints));

        return policyBuilder.Build();
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        var policyBuilder = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
        
        policyBuilder.RequireAuthenticatedUser();

        return Task.FromResult(policyBuilder.Build());
    }

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy?>(null);
}
