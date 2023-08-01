using System.Globalization;

namespace Deprecation.StringUtils
{
    public class StringUtils
    {

        [Obsolete("This method is deprecated since version 2.0.0. Use ReverseStringV2 instead.", false)]
        public static string ReverseString(string originalString)
        {
            var charArray = originalString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string ReverseStringV2(string originalString)
        {
            return string.Create(originalString.Length, originalString, (chars, val) =>
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