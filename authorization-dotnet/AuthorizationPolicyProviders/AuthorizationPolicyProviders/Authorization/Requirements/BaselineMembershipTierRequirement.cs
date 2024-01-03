using AuthorizationPolicyProviders.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Authorization.Requirements;

public class BaselineMembershipTierRequirement : IAuthorizationRequirement
{
    public MembershipTier BaselineMembershipTier { get; set; }

    public BaselineMembershipTierRequirement(MembershipTier baselineMembershipTier)
    {
        BaselineMembershipTier = baselineMembershipTier;
    }
}
