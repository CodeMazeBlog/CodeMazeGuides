namespace EscapingCurlyBracketsInFormatStrings
{
    public static class FormatStringsEscaping
    {
        public static string FormatStringExample()
        {
            var name = "John";
            var formattedString = string.Format("Hello, {0}!", name);

            return formattedString;
        }

        public static string CurlyBracketsEscaping()
        {
            var formatValue = "World";
            var formattedString = string.Format("{{Hello, {0}!}}", formatValue);

            return formattedString;
        }

        public static string DoubleQuotesEscaping()
        {
            var message = "Important message";
            var formattedString = string.Format("\"{0}\" is the message.", message);

            return formattedString;
        }

        public static string BackslashEscaping()
        {
            var path = @"C:\Program Files\";
            var formattedString = string.Format("The installation path is: {0}", path);

            return formattedString;
        }
    }
}
