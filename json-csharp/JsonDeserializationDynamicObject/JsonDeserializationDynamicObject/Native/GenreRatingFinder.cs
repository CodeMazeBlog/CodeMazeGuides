using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonDeserializationDynamicObject.Native;

public static class GenreRatingFinder
{
    public static (string? Genre, double Imdb) UsingAnonymousType(string jsonString)
    {
        var anonymous = DeserializeAnonymousType(jsonString, new
        {
            Genre = string.Empty,
            Rating = new { Imdb = 0d }
        })!;

        var genre = anonymous.Genre;
        var imdb = anonymous.Rating.Imdb;

        return (genre, imdb);
    }

    static T DeserializeAnonymousType<T>(string jsonString, T anonymousObject)
        => JsonSerializer.Deserialize<T>(jsonString)!;    

    public static (string? Genre, double Imdb, double Rotten) UsingJsonElement(string jsonString)
    {
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(jsonString);

        return FromJsonElement(jsonElement);
    }

    private static (string? Genre, double Imdb, double Rotten) FromJsonElement(JsonElement jsonElement)
    {
        var genre = jsonElement
            .GetProperty("Genre")
            .GetString();

        var imdb = jsonElement
            .GetProperty("Rating")
            .GetProperty("Imdb")
            .GetDouble();

        var rotten = jsonElement
            .GetProperty("Rating")
            .GetProperty("Rotten Tomatoes")
            .GetDouble();

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingJsonDocument(string jsonString)
    {
        //using var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(jsonString)!;
        using var jsonDocument = JsonDocument.Parse(jsonString);

        return FromJsonElement(jsonDocument.RootElement);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingJsonObject(string jsonString)
    {
        var jsonDom = JsonSerializer.Deserialize<JsonObject>(jsonString)!;

        var genre = (string)jsonDom["Genre"]!;
        var imdb = (double)jsonDom["Rating"]!["Imdb"]!;
        var rotten = (double)jsonDom["Rating"]!["Rotten Tomatoes"]!;

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingJsonNode(string jsonString)
    {
        var jsonDom = JsonSerializer.Deserialize<JsonNode>(jsonString)!; 

        var genre = (string)jsonDom["Genre"]!;
        var imdb = (double)jsonDom["Rating"]!["Imdb"]!;
        var rotten = (double)jsonDom["Rating"]!["Rotten Tomatoes"]!;

        return (genre, imdb, rotten);
    }
}