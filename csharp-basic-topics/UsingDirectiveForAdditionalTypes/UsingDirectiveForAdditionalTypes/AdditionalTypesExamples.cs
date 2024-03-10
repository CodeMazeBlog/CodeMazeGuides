using System.Collections.Generic;
using System.Linq;
using NullableInt = int?;
using Point = (int X, int Y);
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

    public static List<Point> GetPointsOfInterest()
    {
        return new List<Point>() { new Point(25, 3), new Point(12, 8), new Point(-2, 0) };
    }
}