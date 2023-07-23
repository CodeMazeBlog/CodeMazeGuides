using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthorization.AuthorizationHandlers;
using ResourceBasedAuthorization.AuthorizationRequirements;

namespace ResourceBasedAuthorization.Tests;

public class UserIsAuthorAuthorizationHandlerUnitTests
{
    [Fact]
    public async Task WhenUserIsAuthor_ThenUserIsAuthorRequirementSucceeds()
    {
        // Arrange
        const string userName = "Jane Doe";
        const string authorName = userName;

        var requirements = new List<IAuthorizationRequirement>();
        var userIsAuthorRequirement = new UserIsAuthorRequirement();
        requirements.Add(userIsAuthorRequirement);

        var blogPost = new BlogPost() { AuthorName = authorName };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Name, userName));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var userIsAuthorAuthorizationHandler = new UserIsAuthorAuthorizationHandler();

        // Act
        await userIsAuthorAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public void WhenUserIsNotAuthor_ThenUserIsAuthorRequirementDoesNotSucceed()
    {
        // Arrange

        const string userName = "Jane Doe";
        const string authorName = "John Doe";

        var requirements = new List<IAuthorizationRequirement>();
        var userIsAuthorRequirement = new UserIsAuthorRequirement();
        requirements.Add(userIsAuthorRequirement);

        var blogPost = new BlogPost() { AuthorName = authorName };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Name, userName));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var userIsAuthorAuthorizationHandler = new UserIsAuthorAuthorizationHandler();

        // Act
        userIsAuthorAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.False(context.HasSucceeded);
        Assert.Contains(userIsAuthorRequirement, context.PendingRequirements);
    }
}