namespace ConvertStringToCharArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var str = "C";

            // Example 1: Using Char.Parse()
            char result = ConvertUsingCharParse(str);
            Console.WriteLine(result);

            str = "Code Maze";

            // Example 2: Using ToCharArray()
            char[] charArray = ConvertToCharArray(str);
            Console.WriteLine(new string(charArray));

            // Example 3: Using For-loop
            charArray = ConvertUsingForLoop(str);
            Console.WriteLine(new string(charArray));

            // Example 4: Conversion from String to ReadOnlySpan<char>
            charArray = ConvertUsingReadOnlySpan(str);
            Console.WriteLine(new string(charArray));

            // Example 5: Using Unsafe Code
            charArray = ConvertUsingUnsafeCode(str);
            Console.WriteLine(new string(charArray));

            // Example 6: Using LINQ Method to Convert String to Char
            charArray = ConvertUsingLinq(str);
            Console.WriteLine(new string(charArray));



        }

        public static char ConvertUsingCharParse(string input)
        {
            return Char.Parse(input);
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
    }
}