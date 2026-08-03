using Microsoft.AspNetCore.Authorization;

namespace CustomAuthorizeAttribute.Authorization.Requirements;

public class SessionRequirement : IAuthorizationRequirement
{
    public SessionRequirement(string sessionHeaderName)
    {
        SessionHeaderName = sessionHeaderName;
    }

    public string SessionHeaderName { get; }
}
