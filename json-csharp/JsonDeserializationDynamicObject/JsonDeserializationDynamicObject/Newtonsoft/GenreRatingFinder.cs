using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace JsonDeserializationDynamicObject.Newtonsoft;

public static class GenreRatingFinder
{
    public static (string? Genre, double Imdb, double Rotten) UsingDynamic(string jsonString)
    {
        var dynamicObject = JsonConvert.DeserializeObject<dynamic>(jsonString)!;

        var genre = dynamicObject.Genre;
        var imdb = dynamicObject.Rating.Imdb;
        var rotten = dynamicObject.Rating["Rotten Tomatoes"];

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingExpandoObject(string jsonString)
    {
        dynamic dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(jsonString)!;

        var genre = dynamicObject.Genre;
        var imdb = dynamicObject.Rating.Imdb;

        IDictionary<string, object> rating = dynamicObject.Rating;
        var rotten = (double)rating["Rotten Tomatoes"];

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb) UsingAnonymousType(string jsonString)
    {
        var anonymous = JsonConvert.DeserializeAnonymousType(jsonString, new 
        { 
            Genre = string.Empty, 
            Rating = new { Imdb = 0d } 
        })!;

        var genre = anonymous.Genre;
        var imdb = anonymous.Rating.Imdb;

        return (genre, imdb);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingAnonymousTypeWithDictionary(string jsonString)
    {
        var anonymous = JsonConvert.DeserializeAnonymousType(jsonString, new
        {
            Genre = string.Empty,
            Rating = new Dictionary<string, double>()
        })!;

        var genre = anonymous.Genre;
        var imdb = anonymous.Rating["Imdb"];
        var rotten = anonymous.Rating["Rotten Tomatoes"];

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingJObject(string jsonString)
    {
        var jsonDom = JsonConvert.DeserializeObject<JObject>(jsonString)!;

        var genre = (string)jsonDom["Genre"]!;
        var imdb = (double)jsonDom["Rating"]!["Imdb"]!;
        var rotten = (double)jsonDom["Rating"]!["Rotten Tomatoes"]!;

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingJToken(string jsonString)
    {
        var jsonDom = JsonConvert.DeserializeObject<JToken>(jsonString)!;

        var genre = (string)jsonDom["Genre"]!;
        var imdb = (double)jsonDom["Rating"]!["Imdb"]!;
        var rotten = (double)jsonDom["Rating"]!["Rotten Tomatoes"]!;

        return (genre, imdb, rotten);
    }

    public static (string? Genre, double Imdb, double Rotten) UsingJsonPath(string jsonString)
    {
        var jsonDom = JsonConvert.DeserializeObject<JObject>(jsonString)!;

        var genre = (string)jsonDom.SelectToken("$.Genre")!;
        var imdb = (double)jsonDom.SelectToken("$.Rating.Imdb")!;
        var rotten = (double)jsonDom.SelectToken("$.Rating['Rotten Tomatoes']")!;

        return (genre, imdb, rotten);
    }
}