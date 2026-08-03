namespace StringInterpolationDemo
{
    public static class VerbatimAndRawStrings
    {
        public static string SimpleVerbatimString(string imageName)
        {
            return @$"C:\images\{imageName}";
        }

        public static string AnotherVerbatimString(string imageName)
        {
            return $@"C:\images\{imageName}";
        }

        public static string SimpleRawString()
        {
            const string canWe = "can";

            return $"""In raw string we {canWe} use " and line break without escaping.""";
        }

        public static string EscapedRawString()
        {
            const string howMany = "the same number";
            const string canWe = "can";

            return $$"""In raw string we use {{howMany}} of {} as $ that prefix the raw string. We {{{canWe}}} also enclose expression.""";
        }
    }
}