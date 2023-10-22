using System;
using System.Linq;

namespace ConvertString2CharArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Example 1: Using ToCharArray()
            var str = "Code Maze";
            char[] charArray = ConvertToCharArray(str);
            Console.WriteLine(new string(charArray));

            // Example 2: Using For-loop
            charArray = ConvertUsingForLoop(str);
            Console.WriteLine(new string(charArray));

            // Example 3: Conversion from String to ReadOnlySpan<char>
            charArray = ConvertUsingReadOnlySpan(str);
            Console.WriteLine(new string(charArray));

            // Example 4: Using Unsafe Code
            charArray = ConvertUsingUnsafeCode(str);
            Console.WriteLine(new string(charArray));

            // Example 5: Using LINQ Method to Convert String to Char
            charArray = ConvertUsingLinq(str);
            Console.WriteLine(new string(charArray));

            // Working with Character Arrays

            // Example 6: Reverse the string
            string originalString = "Hello, C#";
            charArray = ReverseString(originalString);
            Console.WriteLine("Reversed String: " + new string(charArray));

            // Example 7: Sort the characters in the string
            charArray = SortString(originalString);
            Console.WriteLine("Sorted String: " + new string(charArray));

            // Example 8: Uppercase the string
            charArray = UppercaseString(originalString);
            Console.WriteLine("Uppercase String: " + new string(charArray));

            // Example 9: Replace 'C#' with 'C++'
            string modifiedString = ReplaceString(originalString, "C#", "C++");
            Console.WriteLine("Modified String: " + modifiedString);
        }

        public static char[] ConvertToCharArray(string str)
        {
            return str.ToCharArray();
        }

        public static char[] ConvertUsingForLoop(string str)
        {
            var charArray = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                charArray[i] = str[i];
            }
            return charArray;
        }

        public static char[] ConvertUsingReadOnlySpan(string str)
        {
            ReadOnlySpan<char> charSpan = str.AsSpan();
            return charSpan.ToArray();
        }

        public static char[] ConvertUsingUnsafeCode(string str)
        {
            unsafe
            {
                char[] charArray;

                fixed (char* p = str)
                {
                    charArray = new char[str.Length];
                    for (int i = 0; i < str.Length; i++)
                    {
                        charArray[i] = p[i];
                    }
                }

                return charArray;
            }
        }

        public static char[] ConvertUsingLinq(string str)
        {
            char[] charArray = str.Select(c => c).ToArray();
            return charArray;
        }

        public static char[] ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return charArray;
        }

        public static char[] SortString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Sort(charArray);
            return charArray;
        }

        public static char[] UppercaseString(string input)
        {
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = char.ToUpper(charArray[i]);
            }
            return charArray;
        }

        public static string ReplaceString(string input, string oldStr, string newStr)
        {
            return input.Replace(oldStr, newStr);
        }
    }
}