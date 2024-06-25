namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        internal static readonly Random random = new Random();
        internal static readonly string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static string? LinqMethod(int length)
        {
            return new string(Enumerable.Repeat(charSet, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
