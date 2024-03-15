using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicyProviders.Authorization.Attributes;

public class LoyaltyAuthorizeAttribute : AuthorizeAttribute
{
    public LoyaltyAuthorizeAttribute(string actionName)
        : base(string.Concat(AuthorizationConstants.LoyaltyPolicyPrefix, actionName)) { }
}
