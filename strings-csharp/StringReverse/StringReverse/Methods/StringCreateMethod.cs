namespace StringReverse
{
    public partial class Methods
    {
        public static string? StringCreateMethod(string s)
        {
            return string.Create(s.Length, s, (chars, state) =>
            {
                state.AsSpan().CopyTo(chars);
                chars.Reverse();
            });
        }
    }
}