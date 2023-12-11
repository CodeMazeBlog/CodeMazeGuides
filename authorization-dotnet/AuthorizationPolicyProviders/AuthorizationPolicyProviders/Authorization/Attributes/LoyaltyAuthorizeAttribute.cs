using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Authorization.Attributes;

public class LoyaltyAuthorizeAttribute : AuthorizeAttribute
{
    private const string POLICY_PREFIX = "Loyalty:";
    
    public LoyaltyAuthorizeAttribute(string actionName)
        : base(string.Concat(POLICY_PREFIX, actionName)) { }
}
