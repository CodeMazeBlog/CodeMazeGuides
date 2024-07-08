using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? OldSpanSecureMethod(int length)
        {
            if (length > 128)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be less than or equal to 128");
            }
            Span<byte> data = stackalloc byte[4 * length];
            RandomNumberGenerator.Fill(data);

            Span<char> result = stackalloc char[length];
            int charSetLength = chars.Length;

            int i = 0;
            int j = 0;
            while (i < length)
            {
                var b = data[j++];
                if (b < 248)
                {
                    result[i++] = chars[b % 62];
                }
            }

            return new string(result);
        }
    }
}
