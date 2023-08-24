using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthorization.AuthorizationHandlers;
using ResourceBasedAuthorization.AuthorizationRequirements;

namespace ResourceBasedAuthorization.Tests;

public class BlogPostCrudOperationsAuthorizationHandlerUnitTests
{
    [Fact]
    public async Task WhenUserHasWriterRole_ThenCreateOperationSucceeds()
    {
        // Arrange
        var requirements = new List<IAuthorizationRequirement>();
        var createRequirement = CrudOperationRequirements.CreateRequirement;
        requirements.Add(createRequirement);

        var blogPost = new BlogPost() { AuthorName = "" };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Role, "Writer"));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenUserDoesNotHaveWriterRole_ThenCreateOperationDoesNotSucceed()
    {
        // Arrange
        var requirements = new List<IAuthorizationRequirement>();
        var createRequirement = CrudOperationRequirements.CreateRequirement;
        requirements.Add(createRequirement);

        var blogPost = new BlogPost() { AuthorName = "" };

        var user = new ClaimsPrincipal(new ClaimsIdentity());

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.False(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenUserIsBlank_ThenReadOperationSucceeds()
    {
        // Arrange
        var requirements = new List<IAuthorizationRequirement>();
        var readRequirement = CrudOperationRequirements.ReadRequirement;
        requirements.Add(readRequirement);

        var blogPost = new BlogPost() { AuthorName = "" };

        var user = new ClaimsPrincipal(new ClaimsIdentity());

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenUserIsBlogPostAuthor_ThenUpdateOperationSucceeds()
    {
        // Arrange
        const string userName = "Jane Doe";
        const string authorName = userName;

        var requirements = new List<IAuthorizationRequirement>();
        var updateRequirement = CrudOperationRequirements.UpdateRequirement;
        requirements.Add(updateRequirement);

        var blogPost = new BlogPost() { AuthorName = authorName };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Name, userName));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenUserIsNotBlogPostAuthor_ThenUpdateOperationDoesNotSucceed()
    {
        // Arrange
        const string userName = "Jane Doe";
        const string authorName = "John Doe";

        var requirements = new List<IAuthorizationRequirement>();
        var updateRequirement = CrudOperationRequirements.UpdateRequirement;
        requirements.Add(updateRequirement);

        var blogPost = new BlogPost() { AuthorName = authorName };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Name, userName));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.False(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenUserIsBlogPostAuthor_ThenDeleteOperationSucceeds()
    {
        // Arrange
        const string userName = "Jane Doe";
        const string authorName = userName;

        var requirements = new List<IAuthorizationRequirement>();
        var deleteRequirement = CrudOperationRequirements.DeleteRequirement;
        requirements.Add(deleteRequirement);

        var blogPost = new BlogPost() { AuthorName = authorName };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Name, userName));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.True(context.HasSucceeded);
    }

    [Fact]
    public async Task WhenUserIsNotBlogPostAuthor_ThenDeleteOperationDoesNotSucceed()
    {
        // Arrange
        const string userName = "Jane Doe";
        const string authorName = "John Doe";

        var requirements = new List<IAuthorizationRequirement>();
        var deleteRequirement = CrudOperationRequirements.DeleteRequirement;
        requirements.Add(deleteRequirement);

        var blogPost = new BlogPost() { AuthorName = authorName };

        var user = new ClaimsPrincipal(new ClaimsIdentity());
        user.Identities.First().AddClaim(new Claim(ClaimTypes.Name, userName));

        AuthorizationHandlerContext context = new AuthorizationHandlerContext(requirements, user, blogPost);

        var blogPostCrudOperationsAuthorizationHandler = new BlogPostCrudOperationsAuthorizationHandler();

        // Act
        await blogPostCrudOperationsAuthorizationHandler.HandleAsync(context);

        // Assert
        Assert.False(context.HasSucceeded);
    }
}
