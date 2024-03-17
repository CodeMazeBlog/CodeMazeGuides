using System.Collections.Generic;
using System.Linq;
using NullableInt = int?;
using Location = (int X, int Y);
using Titles = string[];

namespace UsingDirectiveForAdditionalTypes;

public static class AdditionalTypesExamples
{
    public static List<NullableInt> GetInts()
    {
        var articles = new List<NullableInt>() { 1, 2, 3, null, 5 };    

        return articles;
    }

    public static Titles GetArticleTitles()
    {
        var articleTitles = AliasExamples.GetArticles()
                                         .Select(a => a.Title)
                                         .ToArray();

        return articleTitles;
    }

    public static List<Location> GetLocationsOfInterest()
    {
        return new List<Location>() { new Location(25, 3), new Location(12, 8), new Location(-2, 0) };
    }
}