using Xunit;
using JsonDeserializationDynamicObject.Newtonsoft;

namespace JsonDeserializationDynamicObject.Tests;

public class NewtonsoftJsonUnitTest
{
    [Fact]
    public void GivenJsonString_WhenUsingDynamic_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingDynamic(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingExpandoObject_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingExpandoObject(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingAnonymousType_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb) = GenreRatingFinder.UsingAnonymousType(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
    }

    [Fact]
    public void GivenJsonString_WhenUsingAnonymousTypeWithDictionary_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingAnonymousTypeWithDictionary(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingJObject_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJObject(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingJToken_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJToken(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingJsonPath_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJsonPath(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }
}