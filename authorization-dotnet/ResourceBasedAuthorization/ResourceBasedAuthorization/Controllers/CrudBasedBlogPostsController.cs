using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResourceBasedAuthorization.AuthorizationRequirements;
using ResourceBasedAuthorization.Repositories;

namespace ResourceBasedAuthorization.Controllers;

[ApiController]
[Route("[controller]")]
public class CrudBasedBlogPostsController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;
    private readonly BlogPostsRepository _blogPostsRepository = new();

    public CrudBasedBlogPostsController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogPostAsync()
    {
        var blogPost = new BlogPost() { AuthorName = User.Identity?.Name ?? "Guest" };

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, blogPost, CrudOperationRequirements.CreateRequirement);

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        await _blogPostsRepository.CreateAsync(blogPost);

        return Ok();
    }

    [HttpGet("{blogPostId}")]
    public async Task<IActionResult> GetBlogPostAsync(string blogPostId)
    {
        BlogPost blogPost = await _blogPostsRepository.GetByIdAsync(blogPostId);

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, blogPost, CrudOperationRequirements.ReadRequirement);

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        return Ok(blogPost);
    }

    [HttpPut("{blogPostId}")]
    public async Task<IActionResult> UpdateBlogPostAsync(string blogPostId)
    {
        BlogPost blogPost = await _blogPostsRepository.GetByIdAsync(blogPostId);

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, blogPost, CrudOperationRequirements.UpdateRequirement);

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        return Ok(blogPost);
    }

    [HttpDelete("{blogPostId}")]
    public async Task<IActionResult> DeleteBlogPostAsync(string blogPostId)
    {
        BlogPost blogPost = await _blogPostsRepository.GetByIdAsync(blogPostId);

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, blogPost, CrudOperationRequirements.DeleteRequirement);

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }

        await _blogPostsRepository.DeleteAsync(blogPostId);

        return NoContent();
    }
}
