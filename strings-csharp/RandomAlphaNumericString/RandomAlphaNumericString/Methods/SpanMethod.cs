using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? SpanMethod(int length)
        {
            Span<char> result = stackalloc char[length];
            int charSetLength = chars.Length;

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(charSetLength);
                result[i] = chars[index];
            }

            return new string(result);
        }
    }
}
