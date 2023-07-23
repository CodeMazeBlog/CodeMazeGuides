using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthorization.AuthorizationRequirements;

namespace ResourceBasedAuthorization.AuthorizationHandlers;

public class UserIsAuthorAuthorizationHandler : AuthorizationHandler<UserIsAuthorRequirement, BlogPost>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        UserIsAuthorRequirement requirement,
        BlogPost blogPost)
    {
        if (context.User.Identity?.Name == blogPost.AuthorName)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
