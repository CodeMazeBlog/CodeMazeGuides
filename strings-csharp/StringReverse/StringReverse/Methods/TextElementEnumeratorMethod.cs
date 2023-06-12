using System.Globalization;

namespace StringReverse
{
    public partial class Methods
    {
        public static string? TextElementEnumeratorMethod(string stringToReverse)
        {
            return string.Create(stringToReverse.Length, stringToReverse, (chars, val) =>
            {
                var valSpan = val.AsSpan();
                var en = StringInfo.GetTextElementEnumerator(val);
                en.MoveNext();
                var start = en.ElementIndex;
                var pos = chars.Length;
                while (en.MoveNext())
                {
                    var next = en.ElementIndex;
                    var len = next - start;
                    valSpan[start..next].CopyTo(chars[(pos - len)..pos]);
                    pos -= len;
                    start = next;
                }

                if (start != 0)
                    valSpan[start..].CopyTo(chars[0..pos]);
            });
        }
    }
}