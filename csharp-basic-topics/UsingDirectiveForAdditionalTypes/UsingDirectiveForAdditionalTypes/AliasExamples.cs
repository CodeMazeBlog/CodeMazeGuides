using System.Collections.Generic;
using CodeMazeArticle = UsingDirectiveForAdditionalTypes.Models.Article;

namespace UsingDirectiveForAdditionalTypes;

public static class AliasExamples
{
    public static List<CodeMazeArticle> GetCodeMazeArticles()
    {
        return new List<CodeMazeArticle>()
        {
            new("How to Use the “Using Static” Feature in C#", 950),
            new("Global Using Directives in C#", 1100),
            new("Using Directive for Additional Types", 800)
        };
    }
}
