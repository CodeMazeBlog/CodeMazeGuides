namespace LINQLikeOperatorTests;

public class LINQLikeOperatorUnitTest : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public LINQLikeOperatorUnitTest(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void WhenQueryKeywordWithWhereAndContains_ThenCorrectArticles()
    {
        List<Article> articles = _fixture.blogDbContext!.Articles.Where(x => x.Title.Contains("n")).ToList();

        Assert.True(articles.Count == 3);
        Assert.Contains(_fixture.startsWithN, articles.Select(x => x.Title));
        Assert.Contains(_fixture.containsN, articles.Select(x => x.Title));
        Assert.Contains(_fixture.endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.notContainsN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenQueryKeywordWithCountAndContains_ThenCorrectCount()
    {
        int articleCounts = _fixture.blogDbContext!.Articles.Count(x => x.Title.Contains("n"));

        Assert.Equal(3, articleCounts);
    }

    [Fact]
    public void WhenQueryKeywordWithFirstOrDefaultAndContains_ThenCorrectArticle()
    {
        Article? firstArticle = _fixture.blogDbContext!.Articles.FirstOrDefault(x => x.Title.Contains("n"));

        Assert.Contains(_fixture.startsWithN, firstArticle!.Title);
    }

    [Fact]
    public void WhenQueryKeywordWithWhereAndStartsWith_ThenCorrectArticles()
    {
        List<Article> articles = _fixture.blogDbContext!.Articles.Where(x => x.Title.StartsWith("n")).ToList();

        Assert.True(articles.Count == 1);
        Assert.Contains(_fixture.startsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.containsN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.notContainsN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenQueryKeywordWithWhereAndEndsWith_ThenCorrectArticles()
    {
        List<Article> articles = _fixture.blogDbContext!.Articles.Where(x => x.Title.EndsWith("n")).ToList();

        Assert.True(articles.Count == 1);
        Assert.DoesNotContain(_fixture.startsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.containsN, articles.Select(x => x.Title));
        Assert.Contains(_fixture.endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.notContainsN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenUsingWildcardsWithWhereAndStartsWith_ThenWildcardDoesNotWork()
    {
        List<Article> articles = _fixture.blogDbContext!.Articles.Where(x => x.Title.StartsWith("_n")).ToList();

        Assert.True(articles.Count == 0);
        Assert.DoesNotContain(_fixture.startsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.containsN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.notContainsN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenUsingWildcardsWithWhereAndEFFunctionLike_ThenCorrectArticles()
    {
        List<Article> articles = _fixture.blogDbContext!.Articles.Where(x => EF.Functions.Like(x.Title, "_n%")).ToList();

        Assert.True(articles.Count == 1);
        Assert.DoesNotContain(_fixture.startsWithN, articles.Select(x => x.Title));
        Assert.Contains(_fixture.containsN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_fixture.notContainsN, articles.Select(x => x.Title));
    }
}