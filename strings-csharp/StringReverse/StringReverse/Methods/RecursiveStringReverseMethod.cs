namespace StringReverse
{
    public partial class Methods
    {
        public static string? RecursiveStringReverseMethod(string stringToReverse)
        {
            if (stringToReverse.Length <= 1)
                return stringToReverse;

            return stringToReverse[^1] + RecursiveStringReverseMethod(stringToReverse[1..^1]) + stringToReverse[0];
        }
    }
}