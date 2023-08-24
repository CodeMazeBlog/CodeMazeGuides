namespace ResourceBasedAuthorization.Repositories;

public class BlogPostsRepository
{
    public Task<BlogPost> GetByIdAsync(string blogPostId)
    {
        return Task.FromResult(new BlogPost() { AuthorName = "Jane Doe" });
    }

    public Task CreateAsync(BlogPost blogPost)
    {
        return Task.CompletedTask;
    }

    public Task SaveAsync(BlogPost blogPost)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string blogPostId)
    {
        return Task.CompletedTask;
    }
}
