namespace JsonToXmlBackAndForth;

public class MovieStats
{
    public static string Xml => @"<?xml version='1.0'?>
    <SquidGame>
      <Genre>Thriller</Genre>
      <Rating Type='Imdb'>8.1</Rating>
      <Stars>Lee Jung-jae</Stars>
      <Stars>Park Hae-soo</Stars>
      <Budget />
    </SquidGame>";

    public static string Json => @"
    {
        ""SquidGame"": {
            ""Genre"": ""Thriller"",
            ""Rating"": {
                ""@Type"": ""Imdb"",
                ""#text"": ""8.1""
            },
            ""Stars"": [""Lee Jung-jae"", ""Park Hae-soo""],
            ""Budget"": null
        }
    }";
}