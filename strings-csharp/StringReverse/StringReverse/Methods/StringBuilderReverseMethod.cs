using System.Text;

namespace StringReverse
{
    public partial class Methods
    {
        public static string? StringBuilderReverseMethod(string stringToReverse)
        {
            var sb = new StringBuilder(stringToReverse.Length);
            for (int i = stringToReverse.Length - 1; i >= 0; i--)
            {
                sb.Append(stringToReverse[i]);
            }

            return sb.ToString();
        }
    }
}