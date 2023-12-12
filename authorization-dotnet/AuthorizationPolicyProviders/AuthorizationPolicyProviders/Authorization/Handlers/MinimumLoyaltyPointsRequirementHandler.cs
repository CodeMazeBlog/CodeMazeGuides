using System.Security.Claims;
using AuthorizationPolicyProviders.Authentication;
using AuthorizationPolicyProviders.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Authorization.Handlers;

public class MinimumLoyaltyPointsRequirementHandler : AuthorizationHandler<MinimumLoyaltyPointsRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumLoyaltyPointsRequirement requirement)
    {   
        _ = int.TryParse(context.User.FindFirstValue(ClaimTypeConstants.LoyaltyPoints), out var loyaltyPoints);

        if (loyaltyPoints >= requirement.MinimumLoyaltyPoints)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
