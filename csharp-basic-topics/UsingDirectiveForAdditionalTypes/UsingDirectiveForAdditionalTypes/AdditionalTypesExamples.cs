using System.Collections.Generic;
using System.Linq;
using NullableInt = int?;
using Location = (int X, int Y);
using Titles = string[];

namespace UsingDirectiveForAdditionalTypes;

public static class AdditionalTypesExamples
{
    public static List<NullableInt> GetArticleIDs()
    {
        return [1, 2, 3, null, 5];
    }

    public static Titles GetArticleTitles()
    {
        return AliasExamples.GetCodeMazeArticles()
                            .Select(a => a.Title)
                            .ToArray();
    }

    public static List<Location> GetLocationsOfInterest()
    {
        return [new Location(25, 3), new Location(12, 8), new Location(-2, 0)];
    }
}