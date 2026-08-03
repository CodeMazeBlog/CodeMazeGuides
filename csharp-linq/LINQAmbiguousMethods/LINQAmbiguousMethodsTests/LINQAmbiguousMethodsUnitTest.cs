namespace LINQAmbiguousMethodsTests;

public class LINQAmbiguousMethodsUnitTest : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public LINQAmbiguousMethodsUnitTest(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void WhenCastToIQueryable_ThenCorrectArticles()
    {
        var articles = ((IQueryable<Article>)_fixture.blogDbContext!.Articles!).Where(x => x.Title == "Some Title");

        Assert.True(articles.Count() == 1);
        Assert.IsAssignableFrom<IQueryable<Article>>(articles);
    }

    [Fact]
    public async Task WhenCastToIAsyncEnumerable_ThenCorrectArticles()
    {
        var articles = ((IAsyncEnumerable<Article>)_fixture.blogDbContext!.Articles!).Where(x => x.Title == "Some Title");

        Assert.True(await articles.CountAsync() == 1);
        Assert.IsAssignableFrom<IAsyncEnumerable<Article>>(articles);
    }

    [Fact]
    public void WhenUseAsQueryable_ThenCorrectArticles()
    {
        var articles = _fixture.blogDbContext!.Articles!.AsQueryable().Where(x => x.Title == "Some Title");

        Assert.True(articles.Count() == 1);
        Assert.IsAssignableFrom<IQueryable<Article>>(articles);
    }

    [Fact]
    public async Task WhenUseAsAsyncEnumerable_ThenCorrectArticles()
    {
        var articles = _fixture.blogDbContext!.Articles!.AsAsyncEnumerable().Where(x => x.Title == "Some Title");

        Assert.True(await articles.CountAsync() == 1);
        Assert.IsAssignableFrom<IAsyncEnumerable<Article>>(articles);
    }
}