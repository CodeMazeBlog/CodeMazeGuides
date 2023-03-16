using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ResourceBasedAuthorization.Controllers;

namespace ResourceBasedAuthorization.Tests;

public class BlogPostsControllerUnitTests
{
    [Fact]
    public async Task GivenUserIsAuthor_WhenUpdateBlogPost_ThenOk()
    {
        // Arrange
        const string policyName = "UserIsAuthorPolicy";
        const string blogPostId = "1";

        var authorizationService = new Mock<IAuthorizationService>();
        authorizationService.Setup(x => x
            .AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), It.IsAny<BlogPost>(), It.Is<string>(y => y == policyName)))
            .ReturnsAsync(AuthorizationResult.Success());

        var blogPostsController = new BlogPostsController(authorizationService.Object);

        // Act
        var result = await blogPostsController.UpdateBlogPostAsync(blogPostId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GivenUserIsNotAuthor_WhenUpdateBlogPost_ThenForbid()
    {
        // Arrange
        const string policyName = "UserIsAuthorPolicy";
        const string blogPostId = "1";

        var authorizationService = new Mock<IAuthorizationService>();
        authorizationService.Setup(x => x
            .AuthorizeAsync(It.IsAny<ClaimsPrincipal>(), It.IsAny<BlogPost>(), It.Is<string>(y => y == policyName)))
            .ReturnsAsync(AuthorizationResult.Failed());

        var blogPostsController = new BlogPostsController(authorizationService.Object);

        // Act
        var result = await blogPostsController.UpdateBlogPostAsync(blogPostId);

        // Assert
        Assert.IsType<ForbidResult>(result);
    }
}
