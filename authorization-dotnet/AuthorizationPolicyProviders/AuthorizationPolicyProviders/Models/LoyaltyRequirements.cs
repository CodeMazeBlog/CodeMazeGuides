namespace AuthorizationPolicyProviders.Models;

public class LoyaltyRequirements
{
    public MembershipTier BaselineMembershipTier { get; set; } = MembershipTier.Standard;
    public int MinimumLoyaltyPoints { get; set; } = 0;
}
