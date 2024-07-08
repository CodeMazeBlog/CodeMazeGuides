using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? PreSpanSecureMethod(int length)
        {
            if (length > 128)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be less than or equal to 128");
            }

            Span<char> result = stackalloc char[length];
            int charSetLength = chars.Length;

            int i = 0;
            while (i < length)
            {
                var b = RandomNumberGenerator.GetInt32(62);
                result[i++] = chars[b];
            }

            return new string(result);
        }
    }
}
