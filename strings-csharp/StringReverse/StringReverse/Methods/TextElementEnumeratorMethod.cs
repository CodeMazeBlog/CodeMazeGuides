using System.Globalization;

namespace StringReverse
{
    public partial class Methods
    {
        public static string? TextElementEnumeratorMethod(string s)
        {
            return string.Create(s.Length, s, (chars, val) =>
            {
                var en = StringInfo.GetTextElementEnumerator(val);
                en.MoveNext();
                var start = en.ElementIndex;
                var pos = chars.Length;
                while (en.MoveNext())
                {
                    var next = en.ElementIndex;
                    var len = next - start;
                    val[start..next].CopyTo(chars[(pos - len)..pos]);
                    pos -= len;
                    start = next;
                }

                if (start != 0)
                    val[start..].CopyTo(chars[0..pos]);
            });
        }
    }
}