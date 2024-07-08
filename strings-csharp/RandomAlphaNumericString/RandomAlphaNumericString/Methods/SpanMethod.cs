namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? SpanMethod(int length)
        {
            if (length > 256)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be less than or equal to 256");
            }
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
