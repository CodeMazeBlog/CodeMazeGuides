using System.Text;

namespace RandomAlphaNumericString
{
    public partial class Methods
    {
        public static string? StringBuilderMethod(int length)
        {
            return Enumerable.Range(0, length)
                      .Aggregate(
                          new StringBuilder(),
                          (sb, n) => sb.Append(chars[random.Next(chars.Length)]),
                          sb => sb.ToString());
        }
    }
}
