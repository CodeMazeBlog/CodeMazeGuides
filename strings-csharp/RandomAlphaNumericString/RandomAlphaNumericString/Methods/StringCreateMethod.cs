namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? StringCreateMethod(int length)
        {
            return string.Create<object?>(length, null,
                static (chars, _) => Random.Shared.GetItems(charSet, chars));
        }
    }
}
