namespace AuthorizationPolicyProviders.Authorization;

public static class AuthorizationConstants
{
    public const string LoyaltyPolicyPrefix = "Loyalty:";
 
    public const string PriorityCheckIn = "PriorityCheckIn";
    public const string PriorityCheckInFull  = $"{LoyaltyPolicyPrefix}{PriorityCheckIn}";
}
