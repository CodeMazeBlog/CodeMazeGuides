namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        private static void FillSpanWithRandomChars(Span<char> span)
        {
            int charSetLength = charSet.Length;
            for (int i = 0; i < span.Length; i++)
            {
                int index = random.Next(charSetLength);
                span[i] = charSet[index];
            }
        }

        public static string? RandomInLoopMethod(int length)
        {
            if (length > 256)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be less than or equal to 256");
            }
            Span<char> result = stackalloc char[length];
            int charSetLength = chars.Length;

            FillSpanWithRandomChars(result);

            return new string(result);
        }
    }
}
