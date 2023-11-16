using System.Runtime.CompilerServices;

namespace InterceptorsInCSharp;

public static class GeneratedCode
{
    [InterceptsLocation("absolute/path/to/program.cs", 9, 28)] 
    [InterceptsLocation("absolute/path/to/program.cs", 10, 35)]
    public static string InterceptorMethod(this Example example, string text)
    {
        return $"{text}, Code Maze!";
    }
}

