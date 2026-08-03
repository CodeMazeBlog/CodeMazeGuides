using System.Collections.Generic;
using static System.Math;

namespace UsingDirectiveForAdditionalTypes;

public static class UsingExamples
{
    public static List<Article> GetArticles()
    {
        return new List<Article>() 
        {
            new("How to Use the “Using Static” Feature in C#", 950),
            new("Global Using Directives in C#", 1100),
            new("Using Directive for Additional Types", 800)
        };
    }

    public static int GetMinimumInteger(int num1, int num2, int num3, int num4)
    {
        return Min(Min(Min(num1, num2), num3), num4);
    }
}