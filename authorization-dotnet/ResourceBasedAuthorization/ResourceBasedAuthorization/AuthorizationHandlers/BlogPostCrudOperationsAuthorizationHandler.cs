using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using ResourceBasedAuthorization.AuthorizationRequirements;

namespace ResourceBasedAuthorization.AuthorizationHandlers;

public class BlogPostCrudOperationsAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, BlogPost>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OperationAuthorizationRequirement requirement,
        BlogPost blogPost)
    {
        switch (requirement.Name)
        {
            case nameof(CrudOperationRequirements.CreateRequirement):
            {
                if (context.User.HasClaim(ClaimTypes.Role, "Writer"))
                {
                    context.Succeed(requirement);
                }

                break;
            }

            case nameof(CrudOperationRequirements.ReadRequirement):
            {
                context.Succeed(requirement);

                break;
            }

            case nameof(CrudOperationRequirements.UpdateRequirement):
            case nameof(CrudOperationRequirements.DeleteRequirement):
            {
                if (context.User.Identity?.Name == blogPost.AuthorName)
                {
                    context.Succeed(requirement);
                }

                break;
            }
        }

        return Task.CompletedTask;
    }
}
