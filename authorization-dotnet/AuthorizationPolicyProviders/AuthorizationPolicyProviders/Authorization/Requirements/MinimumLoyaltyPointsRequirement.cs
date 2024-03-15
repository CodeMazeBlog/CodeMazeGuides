using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Authorization.Requirements;

public class MinimumLoyaltyPointsRequirement : IAuthorizationRequirement
{
    public int MinimumLoyaltyPoints { get; set; }

    public MinimumLoyaltyPointsRequirement(int minimumLoyaltyPoints)
    {
        MinimumLoyaltyPoints = minimumLoyaltyPoints;
    }
}
