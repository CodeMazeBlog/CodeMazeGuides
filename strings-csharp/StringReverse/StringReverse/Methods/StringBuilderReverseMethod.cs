using System.Text;

namespace StringReverse
{
    public partial class Methods
    {
        public static string? StringBuilderReverseMethod(string s)
        {
            var sb = new StringBuilder(s.Length);
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }
    }
}