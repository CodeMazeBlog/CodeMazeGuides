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

        public static string UnescapedCurlyBrackets()
        {
            var formatValue = "World";
            var formattedString = string.Format("{Hello, {0}!}", formatValue);

            return formattedString;
        }

        public static string CurlyBracketsEscaping()
        {
            var formatValue = "World";
            var formattedString = string.Format("{{Hello, {0}!}}", formatValue);

            return formattedString;
        }

        public static string InterpolatedCurlyBracketsEscaping()
        {
            var formatValue = "World";
            var formattedString = $"{{Hello, {formatValue}!}}";

            return formattedString;
        }

        public static string FormatSpecifierInsideCurlyBrackets()
        {
            var orderNumber = 42;
            var formattedString = string.Format("Order {{{0:D5}}}", orderNumber);

            return formattedString;
        }

        public static string InterpolatedFormatSpecifierInsideCurlyBrackets()
        {
            var orderNumber = 42;
            var formattedString = $"Order {{{orderNumber:D5}}}";

            return formattedString;
        }

        public static string RawStringLiteralJson()
        {
            var name = "John";
            var age = 30;
            var json = $$"""
                {
                  "name": "{{name}}",
                  "age": {{age}}
                }
                """;

            return json;
        }

        public static string DoubleQuotesEscaping()
        {
            var message = "Important message";
            var formattedString = string.Format("\"{0}\" is the message.", message);

            return formattedString;
        }

        public static string DoubleQuotesInVerbatimString()
        {
            var message = "Important message";
            var formattedString = string.Format(@"""{0}"" is the message.", message);

            return formattedString;
        }

        public static string DoubleQuotesInRawStringLiteral()
        {
            var message = "Important message";
            var formattedString = string.Format("""
                "{0}" is the message.
                """, message);

            return formattedString;
        }

        public static string BackslashEscaping()
        {
            var path = "C:\\Program Files\\";
            var formattedString = string.Format("The installation path is: {0}", path);

            return formattedString;
        }

        public static string BackslashInVerbatimString()
        {
            var path = @"C:\Program Files\";
            var formattedString = string.Format("The installation path is: {0}", path);

            return formattedString;
        }
    }
}
