namespace StringReverse
{
    public partial class Methods
    {
        public static string? StringCreateMethod(string stringToReverse)
        {
            return string.Create(stringToReverse.Length, stringToReverse, (chars, state) =>
            {
                state.AsSpan().CopyTo(chars);
                chars.Reverse();
            });
        }
    }
}