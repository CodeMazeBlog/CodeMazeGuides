using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceSpecialCharactersInString
{
    public class ReplaceSpecialCharactersInString
    {
        static void Main()
        {
            StringReplaceExample();

            LossOfOriginalStructureStringReplaceExample();

            InefficientMultipleReplacementsStringReplaceExample();

            MemoryImpactStringReplaceExample();

            StringBuilderExample();

            RegexExample();

            SpanTExample();

            CompiledRegexExample();

            DotNet8FeaturesExample();

            UnsafeCodeExample();
        }

        public static void StringReplaceExample()
        {
            string originalString = "Hello! This is a #sample# string.";
            string replacedString = originalString.Replace("#", "");

            Console.WriteLine("String.Replace Method: " + replacedString);
        }

        public static void LossOfOriginalStructureStringReplaceExample()
        {
            string originalString = "apple, banana, cherry";
            string replacedString = originalString.Replace(",", "");

            Console.WriteLine("Loss of Original Structure using String.Replace: " + replacedString);
        }

        public static void InefficientMultipleReplacementsStringReplaceExample()
        {
            string originalString = "a*b*c*d*e*f*g";
            string replacedString = originalString.Replace("*", "").Replace("c", "").Replace("g", "");

            Console.WriteLine("Inefficient for Multiple Replacements using String.Replace Method: " + replacedString);
        }

        public static void MemoryImpactStringReplaceExample()
        {
            string originalString = "a" + new string('x', 1000000) + "b"; 
            string replacedString = originalString.Replace("x", "");

            Console.WriteLine("Memory Impact using String.Replace Method: " + replacedString);
        }

        public static void StringBuilderExample()
        {
            string originalString = "a*b*c*d*e*f*g";

            StringBuilder sb = new StringBuilder(originalString);
            sb.Replace("*", "").Replace("c", "").Replace("g", "");

            string replacedString = sb.ToString();

            Console.WriteLine("StringBuilder for Multiple Replacements: " + replacedString);
        }

        public static void RegexExample()
        {
            string originalString = "Hello! This is a #sample# string.";
            string pattern = "[#]";
            string replacedString = Regex.Replace(originalString, pattern, "");

            Console.WriteLine("Regular Expressions (Regex): " + replacedString);
        }

        public static void SpanTExample()
        {
            char[] originalChars = "Hello! This is a #sample# string.".ToCharArray();

            Span<char> span = new Span<char>(originalChars);
            span.Slice(17, 8).Clear();

            string resultString = new string(span.ToArray());

            Console.WriteLine("Memory-Efficient Replacements with Span<T>: " + resultString);
        }

        public static void CompiledRegexExample()
        {
            Regex compiledRegex = new Regex("[#]", RegexOptions.Compiled);
            string replacedString = compiledRegex.Replace("Hello! This is a #sample# string.", "");

            Console.WriteLine("Compiled Regex for Repeated Operations: " + replacedString);
        }

        public static void DotNet8FeaturesExample()
        {
            string replacedString = Regex.Replace("Hello! This is a #sample# string.", "[#]", "", RegexOptions.NonBacktracking);

            Console.WriteLine(".NET 8 Features: " + replacedString);
        }

        public static void UnsafeCodeExample()
        {
            string originalString = "Hello! This is a #sample# string.";

            unsafe
            {
                fixed (char* ptr = originalString)
                {
                    for (int i = 0; i < originalString.Length; i++)
                    {
                        if (ptr[i] == '#')
                            ptr[i] = '*';
                    }
                }
            }

            Console.WriteLine("Unsafe Code for Direct Memory Access: " + originalString);
        }
    }
}
