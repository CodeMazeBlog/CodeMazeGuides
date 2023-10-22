using System;
using System.Linq;

namespace ConvertString2CharArray
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Methods for Converting Strings to Characters
            var str = "Code Maze";

            // Using ToCharArray()
            char[] charArray = str.ToCharArray();
            Console.WriteLine(charArray);

            // Using For-loop
            var charArray2 = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                charArray2[i] = str[i];
            }
            Console.WriteLine(charArray2);

            // Conversion from String to ReadOnlySpan<char>
            ReadOnlySpan<char> charSpan = str;
            string charString = charSpan.ToString();
            Console.WriteLine(charString);

            /* Using Unsafe Code
              ```
               you must enable unsafe code in your project settings to compile and run this code.
               1. Right - click on your project in Solution Explorer.
               2. Select "Properties."
               3. Under the "Build" tab, check the "Allow unsafe code" option. 
               ```
            */
            unsafe
            {
                char[] charArray3;

                fixed (char* p = str)
                {
                    charArray3 = new char[str.Length];
                    for (int i = 0; i < str.Length; i++)
                    {
                        charArray3[i] = p[i];
                    }
                }

                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(charArray3[i]);
                }
            }
            Console.WriteLine(); // Add new line

            // Using the LINQ Method to Convert String to Char
            char[][] charArrays = str.Select(c => new char[] { c }).ToArray();
            foreach (char[] charArray4 in charArrays)
            {
                Console.Write(charArray4); // Print individual charArray4
            }
            Console.WriteLine(); // Add new line

            #endregion

            #region Working with Character Arrays

            // Original string
            var text = "Hello, C#";

            // Convert the string to a character array using ToCharArray() method
            char[] charArray5 = text.ToCharArray();

            // Example 1: Reverse the string
            Array.Reverse(charArray5);
            Console.WriteLine("Reversed String: " + new string(charArray5));

            // Example 2: Sort the characters in the string
            Array.Sort(charArray5);
            Console.WriteLine("Sorted String: " + new string(charArray5));

            // Example 3: Uppercase the string
            for (int i = 0; i < charArray5.Length; i++)
            {
                charArray5[i] = char.ToUpper(charArray5[i]);
            }
            Console.WriteLine("Uppercase String: " + new string(charArray5));

            // Example 4: Replace 'C#' with 'C++'
            string modifiedString = new string(charArray5);
            modifiedString = modifiedString.Replace("C#", "C++");
            Console.WriteLine("Modified String: " + modifiedString);

            #endregion
        }
    }
}
