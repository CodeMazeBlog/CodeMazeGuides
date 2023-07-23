using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceBasedAuthorization.Repositories;

namespace ResourceBasedAuthorization.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogPostsController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;
    private readonly BlogPostsRepository _blogPostsRepository;

    public BlogPostsController(IAuthorizationService authorizationService, BlogPostsRepository blogPostsRepository)
    {
        _authorizationService = authorizationService;
        _blogPostsRepository = blogPostsRepository;
    }

    [Authorize]
    [HttpPut("{blogPostId}")]
    public async Task<IActionResult> UpdateBlogPostAsync(string blogPostId)
    {
        BlogPost blogPost = await _blogPostsRepository.GetByIdAsync(blogPostId);

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, blogPost, "UserIsAuthorPolicy");

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        await _blogPostsRepository.SaveAsync(blogPost);

        return Ok(blogPost);
    }
}
