using System.Security.Claims;
using AuthorizationPolicyProviders.Authentication;
using AuthorizationPolicyProviders.Authorization.Requirements;
using AuthorizationPolicyProviders.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Authorization.Handlers;

public class BaselineMembershipTierRequirementHandler : AuthorizationHandler<BaselineMembershipTierRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BaselineMembershipTierRequirement requirement)
    {
        MembershipTier? membershipTier = context.User.FindFirstValue(ClaimTypeConstants.MembershipTier) switch
        {
            var membershipTierName when membershipTierName is not null =>
                Enum.Parse<MembershipTier>(membershipTierName),
            _ => null
        };

        if (membershipTier.HasValue && membershipTier.Value >= requirement.BaselineMembershipTier)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
