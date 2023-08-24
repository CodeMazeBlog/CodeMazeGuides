namespace JsonDeserializationDynamicObject;

public class MovieStats
{
    public static string SquidGame => @"
    {
        ""Name"": ""Squid Game"",
        ""Genre"": ""Thriller"",
        ""Rating"": {
            ""Imdb"": 8.1,
            ""Rotten Tomatoes"": 0.94
        },
        ""Year"": 2021,
        ""Stars"": [""Lee Jung-jae"", ""Park Hae-soo""],
        ""Language"": ""Korean"",
        ""Budget"": ""$21.4 million""
    }";
}