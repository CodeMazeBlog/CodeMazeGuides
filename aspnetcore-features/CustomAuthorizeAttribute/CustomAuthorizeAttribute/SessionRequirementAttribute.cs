using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuthorizeAttribute;

public class SessionRequirementAttribute : TypeFilterAttribute
{
    public SessionRequirementAttribute() : base(typeof(SessionRequirementFilter))
    {
    }
}

public class SessionRequirementFilter : IAuthorizationFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionRequirementFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!_httpContextAccessor.HttpContext!.Request.Headers["X-Session-Id"].Any())
        {
            context.Result = new UnauthorizedObjectResult(string.Empty);
            return;
        }
    }
}
