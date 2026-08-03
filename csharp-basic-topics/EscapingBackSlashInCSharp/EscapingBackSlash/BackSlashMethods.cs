public static class BackslashMethods
{
    public static string UsingDoubleBackslash()
    {
        return "C:\\Users\\User\\Documents";
    }

    public static string UsingVerbatimStringLiteral()
    {
        return @"C:\Users\User\Documents";
    }

    public static string UsingUnicodeEscapeSequence()
    {
        return "C:\u005CUsers\u005CUser\u005CDocuments";
    }

    public static string UsingStringFormat()
    {
        return string.Format("C:{0}Users{0}User{0}Documents", Path.DirectorySeparatorChar);
    }

    public static string UsingStringInterpolation()
    {
        return $"C:{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}User{Path.DirectorySeparatorChar}Documents";
    }

    public static string UsingRawStringLiterals()
    {
        return """C:\Users\User\Documents""";
    }
}