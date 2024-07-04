using System.Security.Cryptography;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? SpanSecureMethod(int length)
        {
            Span<byte> data = stackalloc byte[4 * length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }

            Span<char> result = stackalloc char[length];
            int charSetLength = chars.Length;
            int acceptableByteRange = 256 - (256 % charSetLength);

            int i = 0;
            int j = 0;
            while (i < length)
            {
                var b = data[j++];
                if (b >= acceptableByteRange)
                {
                    b = data[j++];
                }

                result[i] = chars[b % charSetLength];
                i++;
            }

            return new string(result);
        }
    }
}
