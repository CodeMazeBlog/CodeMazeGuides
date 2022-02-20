namespace Tests;

using Microsoft.EntityFrameworkCore;
using Minimal_API;
using System.Threading.Tasks;
using Xunit;

public class MinimalAPITest
{
    [Fact]
    public async Task GivenArticleRequest_WhenArticleIsCreated_ThenArticleIsCreatedSuccessfully()
    {
        // Given
        var articleRequest = new ArticleRequest("Title", "Content", null);

        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "api1")
            .Options;

        var apiContext = new ApiContext(options);

        // When
        await ArticleService.CreateArticle(articleRequest, apiContext);

        // Then
        Assert.True(await apiContext.Articles.FirstOrDefaultAsync() != null);
    }

    [Fact]
    public async Task GivenExistingArticle_WhenArticleIsUpdated_ThenArticleIsUpdatedSuccessfully()
    {
        // Given
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "api2")
            .Options;

        var apiContext = new ApiContext(options);
        apiContext.Articles.Add(new Article { Title = "Title", Content = "Content" });
        apiContext.SaveChanges();

        var articleRequest = new ArticleRequest("Title2", "Content", null);

        // When
        await ArticleService.UpdateArticle(1, articleRequest, apiContext);

        // Then
        var updatedArticle = await apiContext.Articles.FirstOrDefaultAsync();

        Assert.Equal("Title2", updatedArticle!.Title);
    }

    [Fact]
    public async Task GivenExistingArticle_WhenArticleIsDeleted_ThenArticleIsDeletedSuccessfully()
    {
        // Given
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "api3")
            .Options;

        var apiContext = new ApiContext(options);
        apiContext.Articles.Add(new Article { Title = "Title", Content = "Content" });
        apiContext.SaveChanges();

        // When
        await ArticleService.DeleteArticle(1, apiContext);

        // Then
        var deletedArticle = await apiContext.Articles.FirstOrDefaultAsync();

        Assert.Null(deletedArticle);
    }

    [Fact]
    public async Task GivenExistingArticle_WhenArticleIsGet_ThenArticleIsGetSuccessfully()
    {
        // Given
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "api4")
            .Options;

        var apiContext = new ApiContext(options);
        apiContext.Articles.Add(new Article { Title = "Title", Content = "Content" });
        apiContext.SaveChanges();

        // When
        await ArticleService.GetArticles(apiContext);

        // Then
        var existingArticle = await apiContext.Articles.FirstOrDefaultAsync();

        Assert.NotNull(existingArticle);
    }

}