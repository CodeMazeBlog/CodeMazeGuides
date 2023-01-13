namespace LINQLikeOperatorTests;

public class LINQLikeOperatorUnitTest : IClassFixture<DatabaseFixture>
{
    private readonly BlogDbContext _blogDbContext;
    private readonly string _startsWithN;
    private readonly string _containsN;
    private readonly string _endsWithN;
    private readonly string _notContainsN;

    public LINQLikeOperatorUnitTest(DatabaseFixture fixture)
    {
        _blogDbContext = fixture.blogDbContext!;
        _startsWithN = fixture.startsWithN;
        _containsN = fixture.containsN;
        _endsWithN = fixture.endsWithN;
        _notContainsN = fixture.notContainsN;
    }

    [Fact]
    public void WhenQueryKeywordWithWhereAndContains_ThenCorrectArticles()
    {
        List<Article> articles = _blogDbContext.Articles.Where(x => x.Title.Contains("n")).ToList();

        Assert.True(articles.Count == 3);
        Assert.Contains(_startsWithN, articles.Select(x => x.Title));
        Assert.Contains(_containsN, articles.Select(x => x.Title));
        Assert.Contains(_endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_notContainsN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenQueryKeywordWithCountAndContains_ThenCorrectCount()
    {
        int articleCounts = _blogDbContext.Articles.Count(x => x.Title.Contains("n"));

        Assert.Equal(3, articleCounts);
    }

    [Fact]
    public void WhenQueryKeywordWithFirstOrDefaultAndContains_ThenCorrectArticle()
    {
        Article? firstArticle = _blogDbContext.Articles.FirstOrDefault(x => x.Title.Contains("n"));

        Assert.Contains(_startsWithN, firstArticle!.Title);
    }

    [Fact]
    public void WhenQueryKeywordWithWhereAndStartsWith_ThenCorrectArticles()
    {
        List<Article> articles = _blogDbContext.Articles.Where(x => x.Title.StartsWith("n")).ToList();

        Assert.True(articles.Count == 1);
        Assert.Contains(_startsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_containsN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_notContainsN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenQueryKeywordWithWhereAndEndsWith_ThenCorrectArticles()
    {
        List<Article> articles = _blogDbContext.Articles.Where(x => x.Title.EndsWith("n")).ToList();

        Assert.True(articles.Count == 1);
        Assert.DoesNotContain(_startsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_containsN, articles.Select(x => x.Title));
        Assert.Contains(_endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(_notContainsN, articles.Select(x => x.Title));
    }
}