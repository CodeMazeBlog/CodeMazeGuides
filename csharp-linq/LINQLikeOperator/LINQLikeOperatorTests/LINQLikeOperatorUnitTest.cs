namespace LINQLikeOperatorTests;

public class LINQLikeOperatorUnitTest : IClassFixture<DatabaseFixture>
{
    private DatabaseFixture fixture;

    public LINQLikeOperatorUnitTest(DatabaseFixture fixture)
    {
        this.fixture = fixture;
    }


    [Fact]
    public void WhenQueryKeywordWithWhereAndContains_ThenCorrectArticles()
    {
        // Arrange
        BlogDbContext blogDbContext = fixture.blogDbContext!;

        // Act
        List<Article> articles = blogDbContext.Articles.Where(x => x.Title.Contains("n")).ToList();

        // Assert
        Assert.True(articles.Count == 3);
        Assert.Contains(fixture.startsWithN, articles.Select(x => x.Title));
        Assert.Contains(fixture.containsN, articles.Select(x => x.Title));
        Assert.Contains(fixture.endsWithN, articles.Select(x => x.Title));
        Assert.DoesNotContain(fixture.notIncludeN, articles.Select(x => x.Title));
    }

    [Fact]
    public void WhenQueryKeywordWithCountAndContains_ThenCorrectCount()
    {
        // Arrange
        BlogDbContext blogDbContext = fixture.blogDbContext!;

        // Act
        int articleCounts = blogDbContext.Articles.Count(x => x.Title.Contains("n"));

        // Assert
        Assert.Equal(3, articleCounts);
    }

    [Fact]
    public void WhenQueryKeywordWithFirstOrDefaultAndContains_ThenCorrectArticle()
    {
        // Arrange
        BlogDbContext blogDbContext = fixture.blogDbContext!;

        // Act
        Article? firstArticle = blogDbContext.Articles.FirstOrDefault(x => x.Title.Contains("n"));

        // Assert
        Assert.Contains(fixture.startsWithN, firstArticle!.Title);
    }
}