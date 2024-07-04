using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? StringCreateSecureMethod(int length)
        {
            return string.Create<object?>(length, null,
                static (chars, _) => RandomNumberGenerator.GetItems(charSet, chars));
        }
    }
}
