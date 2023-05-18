using System.Runtime.InteropServices;

namespace ConvertStringToSpan
{
    public static class StringExample
    {
        public static Span<char> ConvertStringToSpanUsingMemoryMarshal(string myString)
        {
            var charArray = myString.ToCharArray();
            var memory = new Memory<char>(charArray);
            var span = MemoryMarshal.Cast<char, char>(memory.Span);

            return span;
        }
        public static unsafe Span<char> ConvertStringToSpanUsingUnsafe(string myString)
        {
            unsafe
            {
                fixed (char* ptr = myString)
                {
                    return new Span<char>(ptr, myString.Length);
                }
            }
        }
        public static Span<char> ConvertStringToSpanUsingAsSpan(string myString)
        {
            var charArray = myString.ToCharArray();
            var span = new Span<char>(charArray);

            return span;
        }
    }
}
