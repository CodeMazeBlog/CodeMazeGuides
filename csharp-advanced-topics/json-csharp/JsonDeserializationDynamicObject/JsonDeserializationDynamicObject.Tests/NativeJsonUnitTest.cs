using JsonDeserializationDynamicObject.Native;
using Xunit;
using System.Text.Json;
using System;

namespace JsonDeserializationDynamicObject.Tests;

public class NativeJsonUnitTest
{
    [Fact]
    public void GivenJsonString_WhenUsingDynamic_ThenDeserializeAsJsonElement()
    {
        var jsonString = MovieStats.SquidGame;

        var dynamicObject = JsonSerializer.Deserialize<dynamic>(jsonString)!;

        Assert.ThrowsAny<Exception>(() => dynamicObject.Genre);
        Assert.IsType<JsonElement>(dynamicObject);
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
    public void GivenJsonString_WhenUsingJsonElement_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJsonElement(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingJsonDocument_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJsonDocument(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingJsonObject_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJsonObject(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }

    [Fact]
    public void GivenJsonString_WhenUsingJsonNode_ThenDynamicallyRetrieveGenreAndRating()
    {
        var jsonString = MovieStats.SquidGame;

        var (genre, imdb, rotten) = GenreRatingFinder.UsingJsonNode(jsonString);

        Assert.Equal("Thriller", genre);
        Assert.Equal(8.1d, imdb);
        Assert.Equal(0.94d, rotten);
    }
}