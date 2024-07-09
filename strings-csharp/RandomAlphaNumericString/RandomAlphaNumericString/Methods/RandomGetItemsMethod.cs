namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? RandomGetItemsMethod(int length)
        {
            return string.Create<object?>(length, null,
                static (chars, _) => FillSpanWithRandomChars(chars));
        }
    }
}
